import { Injectable } from '@angular/core';
import { SignInModel } from '../models/signin.model';
import { Observable, BehaviorSubject, Subscription } from 'rxjs';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { IAuthService } from 'src/app/core/services/auth.service';
import { SignInUserCommand } from 'src/app/core/commands/user.commnd';
import { GError } from 'src/app/core/results/error';
import { finalize } from 'rxjs/operators';

@Injectable()
export abstract class ISignInFacade {
  /**
   * Viewmodel that resolves once all the data is ready (or updated)...
   */
  readonly ViewModel$: Observable<SignInModel>;
  /**
   * perform signup request and change state according to response
   */
  abstract SignInAsync(): Promise<void>;
  /**
   * build signup form that used to catch signup data
   */
  abstract BuildForm(): FormGroup;
}

@Injectable()
export class SignInFacade implements ISignInFacade {
  private command: SignInUserCommand;

  private state: SignInModel = {};
  private store = new BehaviorSubject<SignInModel>(this.state);

  private state$ = this.store.asObservable();

  constructor(
    private authService: IAuthService,
    private formBuilder: FormBuilder
  ) { }

  public ViewModel$ = this.state$;

  // ------- Private Methods ------------------------
  private updateState(state: SignInModel) {
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

  // 
  public async SignInAsync(): Promise<void> {
    try {
      await this.authService.SignInAsync(this.command);
      this.subscriptions.forEach(sub => {
        sub.unsubscribe();
      });
    } catch (errors) {
      console.log(errors);
      const credentialsErrors = errors?.filter((e: GError) =>
        e.Code.endsWith('Credentials')
      );
      const passwordErrors = errors?.filter((e: GError) =>
        e.Code.endsWith('Password')
      );

      if (credentialsErrors?.length > 0) {
        this.credentials.setErrors({ serverErrors: credentialsErrors });
      }
      if (passwordErrors?.length > 0) {
        this.password.setErrors({ serverErrors: passwordErrors })
      }
    }
  }

  private credentials: FormControl;
  private password: FormControl;
  private subscriptions: Subscription[] = [];

  public BuildForm(): FormGroup {
    this.credentials = this.formBuilder.control('',
      [
        Validators.required,
        Validators.maxLength(40)
      ]
    );

    let sub;

    sub = this.credentials.statusChanges.subscribe(status => {
      if (status == 'INVALID') {
        const errors = this.extractErrors(this.credentials);
        this.updateState({ ...this.state, CredentialsErrors: errors })
      }
    })
    this.subscriptions = [...this.subscriptions, sub];

    this.password = this.formBuilder.control('',
      [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(128)
      ]
    );

    sub = this.password.statusChanges.subscribe(status => {
      if (status == 'INVALID') {
        const errors = this.extractErrors(this.password);
        this.updateState({ ...this.state, PasswordErrors: errors })
      }
    })
    this.subscriptions = [...this.subscriptions, sub];

    const signInForm = this.formBuilder.group({
      credentials: this.credentials,
      password: this.password
    });

    sub = signInForm.valueChanges.pipe(
      finalize(() => { this.command = null }) // delete data
    ).subscribe(value => {
      this.command = value;
    })
    this.subscriptions = [...this.subscriptions, sub];

    return signInForm;
  }

}
