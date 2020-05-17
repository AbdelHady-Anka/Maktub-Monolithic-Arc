import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './shared/material.module';
import { ServiceWorkerModule } from '@angular/service-worker';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { AuthModule } from './auth/auth.module';
import { RootModule } from './root/root.module';
import { ErrorModule } from './error/error.module';
import { HttpInterceptorProviders } from './core/interceptors/interceptors';
import { IStorageService, StorageService } from './core/services/storage.service';
import { LangFacade, ILangFacade } from './core/facades/lang.facade';
import { ServiceProviders } from './core/services/services';
import { CoreModule } from './core/core.module';


export function TranslateHttpLoaderFactory(http: HttpClient) {
   return new TranslateHttpLoader(http, 'assets/i18n/', '.json');
}

@NgModule({
   declarations: [
      AppComponent,
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      MaterialModule,
      AuthModule,
      RootModule,
      HttpClientModule,
      ServiceWorkerModule.register('ngsw-worker.js', { enabled: true }),
      TranslateModule.forRoot({
         defaultLanguage: 'en',
         loader: {
            provide: TranslateLoader,
            useFactory: TranslateHttpLoaderFactory,
            deps: [HttpClient]
         }
      }),
      CoreModule,
      ErrorModule,
   ],
   providers: [
      { provide: ILangFacade, useClass: LangFacade }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
