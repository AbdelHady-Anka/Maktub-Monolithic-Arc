import { NgModule } from '@angular/core';

import { AuthRoutingModule } from './auth-routing.module';
import { SignUpComponent } from './signup/signup.component';
import { MaterialModule } from '../shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { AuthComponent } from './auth.component';
import { SignUpFacade, ISignUpFacade } from './facades/signup.facade';
import { ILangFacade, LangFacade } from '../core/facades/lang.facade';
import { FacadeProviders } from './facades';
import { SignInComponent } from './signin/signin.component';


@NgModule({
  declarations: [SignUpComponent, AuthComponent, SignInComponent],
  imports: [
    SharedModule,
    AuthRoutingModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    TranslateModule.forChild({
      extend: true,
      loader: {
        provide: TranslateLoader,
        useFactory: TranslateHttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: true,
      defaultLanguage: 'en'
    })
  ],
  providers: [
    { provide: ILangFacade, useClass: LangFacade },
    FacadeProviders
  ]
})
export class AuthModule { }

export function TranslateHttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, 'assets/i18n/auth/', '.json');
}