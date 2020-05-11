import { Provider } from '@angular/core';
import { AuthService, IAuthService } from './auth.service';

export const ServiceProviders: Provider[] = [
    { provide: IAuthService, useClass: AuthService },

];