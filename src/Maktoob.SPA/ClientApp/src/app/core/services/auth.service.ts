import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GResult } from '../results/result';
import { SignInUserCommand, SignUpUserCommand } from '../commands/user.commnd';
import { TokenModel, JwtClaimNames } from '../models/token.model';
import { tap, map, distinctUntilChanged, share, filter, take, switchMap, finalize, mergeMap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Observable, BehaviorSubject } from 'rxjs';
import { TokenState } from '../states/auth.state';
import { IStorageService } from './storage.service';

@Injectable()
export abstract class IAuthService {
  abstract SignUpAsync(command: SignUpUserCommand): Promise<GResult<any>>
  abstract SignInAsync(command: SignInUserCommand): Promise<void>
  abstract UpdateToken(token: TokenModel): void;
  abstract IsTokenExpired(): boolean;
  abstract IsAuthorizedAsync(): Promise<boolean>;
  abstract RefreshToken(): Observable<void>
  abstract SignOutAsync(): Promise<void>
  abstract get AccessToken(): string;
}


@Injectable()

export class AuthService implements IAuthService {

  private BASE_URL = this.API_BASE_URL + 'auth/';

  private state: TokenState;

  constructor(
    private http: HttpClient,
    private storageService: IStorageService,
    private router: Router,
    @Inject('API_BASE_URL') private API_BASE_URL
  ) {
    const tokenModel = this.storageService.GetItem<TokenModel>('token');
    const claims = this.parseJwt(tokenModel?.AccessToken);
    this.state = { TokenModel: tokenModel, Claims: claims } as TokenState;
  }
  get AccessToken(): string {
    return this.state?.TokenModel?.AccessToken;
  }

  UpdateToken(tokenModel: TokenModel): void {
    const claims = this.parseJwt(tokenModel?.AccessToken);
    this.state = { TokenModel: tokenModel, Claims: claims } as TokenState;

    this.storageService.SetItem('token', tokenModel);
    if (!tokenModel) {
      this.storageService.RemoveItem('token');
    }
  }


  public IsTokenExpired(): boolean {
    const now = Date.now() / 1000;
    const exp = this.state?.Claims ? this.state.Claims[JwtClaimNames.Exp] as number : 0;
    if (exp < now) {
      this.previousTokenExpired = this.tokenExpired;
      this.tokenExpired = true;
      return true;
    }
    this.previousTokenExpired = this.tokenExpired;
    this.tokenExpired = false;
    return false;
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
    const result = await this.http.post<GResult>(this.BASE_URL + 'SignUp', command).toPromise();
    if (result.Succeeded) {
      const signInCommand = { Credentials: command.UserName, Password: command.Password, EmailCredentials: false } as SignInUserCommand;

      await this.SignInAsync(signInCommand);
    }
    return result;
  }

  public async SignInAsync(command: SignInUserCommand): Promise<void> {
    const result = await this.http.post<GResult<any>>(this.BASE_URL + 'SignIn', command).toPromise();
    if (result.Succeeded) {
      this.UpdateToken(result.Outcome);
      this.router.navigate(['']);
    }
  }

  private refreshToken$: Observable<void>;
  private tokenExpired = false
  private previousTokenExpired = false
  // private tokenExpired$ = this.tokenExpired.asObservable().pipe(
  // distinctUntilChanged()
  // )

  public RefreshToken(): Observable<void> {
    const command = { ...this.state.TokenModel };

    if (this.tokenExpired && this.tokenExpired != this.previousTokenExpired) { // first time token expired only
      this.refreshToken$ = this.http.post<GResult<TokenModel>>(this.BASE_URL + 'RefreshToken', command)
        .pipe(
          tap(result => {
            this.UpdateToken(result.Outcome);
          }),
          share(),
          map(_ => { })
        );
    }

    return this.refreshToken$;
  }

  public async SignOutAsync(): Promise<void> {
    const command = { ...this.state.TokenModel };
    try {
      const result = await this.http.post<GResult>(this.BASE_URL + 'SignOut', command).toPromise();
      if (result?.Succeeded) {
        // signout
        this.UpdateToken(null);
        this.router.navigate(['/auth']);
      }
    } catch (errors) {
      errors.forEach(error => {
        if (error?.Code == 'Unauthorized') {
          // signout
          this.UpdateToken(null);
          this.router.navigate(['/auth']);
        }
      })
    }
  }

  private parseJwt(token: string) {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch {
      return {};
    }
  };
}