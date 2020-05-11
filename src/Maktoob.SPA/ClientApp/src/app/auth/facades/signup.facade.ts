import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { SignUpUserCommand } from 'src/app/core/commands/user.commnd';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { GError } from 'src/app/core/results/error';
import { IAuthService } from 'src/app/core/services/auth.service';
import { SignUpModel } from '../models/signup.mode';
import { finalize } from 'rxjs/operators';



@Injectable()
export abstract class ISignUpFacade {
  /**
  * Viewmodel that resolves once all the data is ready (or updated)...
  */
  readonly ViewModel$: Observable<SignUpModel>;
  /**
   * perform signup request and change state according to response
   */
  abstract SignUpAsync(): Promise<void>;
  /**
   * build signup form that used to catch signup data
   */
  abstract BuildForm(): FormGroup;
}


@Injectable()
export class SignUpFacade implements ISignUpFacade {

  private command: SignUpUserCommand;

  private state: SignUpModel = {};
  private store = new BehaviorSubject<SignUpModel>(this.state);

  private state$ = this.store.asObservable();

  public ViewModel$ = this.state$;


  private username: FormControl;
  private password: FormControl;
  private email: FormControl;

  constructor(
    private formBuilder: FormBuilder,
    private authService: IAuthService,
  ) { }



  // ------- Private Methods ------------------------

  /** Update internal state cache and emit from store... */
  private updateState(state: SignUpModel) {
    this.store.next(this.state = state);
  }

  private extractErrors(field: FormControl): GError[] {
    let errors = Object.getOwnPropertyNames(field.errors).filter(key => key !== 'serverErrors').map(key => {
      return { Code: key, Description: undefined } as GError;
    });
    if (field.errors['serverErrors']) {
      errors = errors.concat(field.errors['serverErrors'] as GError[]);
    }
    return errors;
  }


  // ------- Public Methods ------------------------

  public async SignUpAsync() {
    try {
      await this.authService.SignUpAsync(this.command);
      this.subscriptions.forEach(sub => {
        sub.unsubscribe();
      })
    } catch (errors) {
      console.log(errors);
      const emailErrors = errors?.filter((e: GError) => e.Code.endsWith('Email'));
      const usernameErrors = errors?.filter((e: GError) => e.Code.endsWith('UserName'));
      const passwordErrors = errors?.filter((e: GError) => e.Code.endsWith('Password'));

      if (emailErrors?.length > 0) {
        this.email.setErrors({ serverErrors: emailErrors });
      }
      if (usernameErrors?.length > 0) {
        this.username.setErrors({ serverErrors: usernameErrors });
      }
      if (passwordErrors?.length > 0) {
        this.password.setErrors({ serverErrors: passwordErrors })
      }
    }
  }


  private subscriptions: Subscription[];

  public BuildForm(): FormGroup {
    let sub;

    this.username = this.formBuilder.control('',
      [
        Validators.required,
        Validators.maxLength(40)
      ]
    );

    this.email = this.formBuilder.control('',
      [
        Validators.required,
        Validators.email
      ]
    );


    this.password = this.formBuilder.control('',
      [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(128)
      ]
    );

    sub = this.username.statusChanges.subscribe(status => {
      if (status === 'INVALID') {
        const errors = this.extractErrors(this.username);
        this.updateState({ ...this.state, UsernameErrors: errors })
      }
    });
    this.subscriptions = [...this.subscriptions, sub];


    sub = this.email.statusChanges.subscribe(status => {
      if (status === 'INVALID') {
        const errors = this.extractErrors(this.email);
        this.updateState({ ...this.state, EmailErrors: errors })
      }
    });
    this.subscriptions = [...this.subscriptions, sub];


    sub = this.password.statusChanges.subscribe(status => {
      if (status === 'INVALID') {
        const errors = this.extractErrors(this.password);
        this.updateState({ ...this.state, PasswordErrors: errors })
      }
    });
    this.subscriptions = [...this.subscriptions, sub];


    const signUpForm = this.formBuilder.group({
      username: this.username,
      email: this.email,
      password: this.password
    });

    sub = signUpForm.valueChanges.pipe(
      finalize(() => {
        this.command = null; // delete data
      })
    ).subscribe((value: SignUpUserCommand) => {
      this.command = value;
    });
    this.subscriptions = [...this.subscriptions, sub];

    return signUpForm;
  }
}
