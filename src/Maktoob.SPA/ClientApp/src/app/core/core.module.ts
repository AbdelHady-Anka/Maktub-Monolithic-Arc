import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpInterceptorProviders } from './interceptors/interceptors';
import { ServiceProviders } from './services/services';
import { ILangFacade, LangFacade } from './facades/lang.facade';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    HttpInterceptorProviders,
    ServiceProviders
  ]
})
export class CoreModule { }
