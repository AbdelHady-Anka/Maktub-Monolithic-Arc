import { NgModule } from '@angular/core';

import { UnprotectedRoutingModule } from './unprotected-routing.module';
import { RegisterComponent } from './register/register.component';
import { MaterialModule } from '../shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';


@NgModule({
  declarations: [RegisterComponent],
  imports: [
    SharedModule,
    UnprotectedRoutingModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    TranslateModule.forChild({
      extend: false,
      loader: {
        provide: TranslateLoader,
        useFactory: TranslateHttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: true,
      defaultLanguage: 'en'
    })
  ]
})
export class UnprotectedModule { }

export function TranslateHttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, 'assets/i18n/unprotected/', '.json');
}