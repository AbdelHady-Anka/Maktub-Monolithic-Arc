import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GResult } from '../results/result';
import { SignInUserCommand, SignUpUserCommand, RefreshTokenCommand, SignOutUserCommand } from '../commands/user.commnd';
import { TokenModel } from '../models/token.model';
import { IAuthFacade } from '../facades/auth.facade';
import { filter, distinctUntilChanged } from 'rxjs/operators';

@Injectable()
export abstract class IAuthService {
  abstract SignUpAsync(command: SignUpUserCommand): Promise<GResult<any>>
  abstract SignInAsync(command: SignInUserCommand): Promise<void>
  abstract RefreshTokenAsync(command: RefreshTokenCommand): Promise<void>
  abstract IsAuthorizedAsync(): Promise<boolean>;
  abstract SignOutAsync(command: SignOutUserCommand): Promise<void>
}


@Injectable()

export class AuthService implements IAuthService {

  private BASE_URL = this.API_BASE_URL + 'auth/';


  constructor(
    private http: HttpClient,
    private authFacade: IAuthFacade,
    @Inject('API_BASE_URL') private API_BASE_URL
  ) {
    this.authFacade.TokenExpired$
      .pipe(
        distinctUntilChanged(),
        filter(expired => expired)
      )
      .subscribe(async _ => {
        await this.RefreshTokenAsync();
      })
  }
  async IsAuthorizedAsync(): Promise<boolean> {
    try {
      await this.http.get(this.BASE_URL + 'IsAuthorized').toPromise();
      return true;
    } catch {
      return false;
    }
  }


  public async SignUpAsync(command: SignUpUserCommand): Promise<GResult<any>> {
    return await this.http.post<GResult>(this.BASE_URL + 'SignUp', command).toPromise();
  }

  public async SignInAsync(command: SignInUserCommand): Promise<void> {
    const result = await this.http.post<GResult<any>>(this.BASE_URL + 'SignIn', command).toPromise();
    if (result.Succeeded) {
      this.authFacade.UpdateToken(result.Outcome);
    }
  }

  public async RefreshTokenAsync(): Promise<void> {
    const command = this.authFacade.GetRefershTokenCommand();
    if (command && Object.keys(command).length !== 0) {
      const result = await this.http.post<GResult<TokenModel>>(this.BASE_URL + 'RefreshToken', command).toPromise();
      this.authFacade.UpdateToken(result.Outcome);
    }
  }

  public async SignOutAsync(): Promise<void> {
    const command = this.authFacade.GetSignOutCommand();
    const result = await this.http.post<GResult>(this.BASE_URL + 'SignOut', command).toPromise();
    if (result.Succeeded) {
      // signout
      this.authFacade.UpdateToken(null);
    }
  }
}