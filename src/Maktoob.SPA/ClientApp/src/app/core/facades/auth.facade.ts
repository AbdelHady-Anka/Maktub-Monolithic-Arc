import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { IStorageService } from '../services/storage.service';
import { TokenModel, JwtClaimNames } from '../models/token.model';
import { map } from 'rxjs/operators';
import { RefreshTokenCommand, SignOutUserCommand } from '../commands/user.commnd';


@Injectable()
export abstract class IAuthFacade {
  abstract UpdateToken(token: TokenModel): void;
  abstract IsTokenExpired(): boolean;
  abstract TokenRequiredUpdate(): void;
  abstract GetRefershTokenCommand(): RefreshTokenCommand
  abstract GetSignOutCommand(): SignOutUserCommand
  abstract GetAccessToken(): string;
  abstract readonly TokenExpired$: Observable<boolean>;
}

@Injectable()

export class AuthFacade implements IAuthFacade {
  private state: TokenModel;

  private state$: Observable<TokenModel> = this.storageService
    .GetState('token').pipe(
      map((token: TokenModel) => {
        if (token) {
          token.Claims = this.parseJwt(token?.AccessToken);
        }
        return token;
      })
    );

  private tokenExpired = new BehaviorSubject<boolean>(true);

  public TokenExpired$ = this.tokenExpired.asObservable();


  constructor(private storageService: IStorageService) {
    this.state$.subscribe(state => {
      this.state = state;
    });
  }

  GetAccessToken(): string {
    return this.state.AccessToken;
  }

  GetSignOutCommand(): SignOutUserCommand {
    const command = { ...this.state };
    delete command.Claims;
    return command as SignOutUserCommand;
  }

  GetRefershTokenCommand(): RefreshTokenCommand {
    const command = { ...this.state };
    delete command.Claims;
    return command as RefreshTokenCommand;
  }

  UpdateToken(token: TokenModel): void {
    const _token = token ? { ...token } : null;
    delete _token?.Claims;
    this.storageService.SetState('token', token);
    if (!token) {
      this.storageService.RemoveItem('token');
      this.tokenExpired.next(true);
      return
    }
    if (!this.IsTokenExpired()) {
      this.tokenExpired.next(false);
    }
  }


  public TokenRequiredUpdate(): void {
    this.tokenExpired.next(true);
  }

  public TokenHasBeenUpdated(): void {
    if (!this.IsTokenExpired()) {
      this.tokenExpired.next(false);
    }
  }

  public IsTokenExpired(): boolean {
    const now = Date.now() / 1000;
    const exp = this.state?.Claims[JwtClaimNames.Exp] as number;
    if (exp < now) {
      return true;
    }
    return false;
  }

  private parseJwt(token: string) {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch (e) {
      return {};
    }
  };
}
