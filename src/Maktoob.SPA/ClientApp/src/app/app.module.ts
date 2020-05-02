import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './shared/material.module';
import { UnprotectedModule } from './unprotected/unprotected.module';
import { ProtectedModule } from './protected/protected.module';
import { NotfoundComponent } from './notfound/notfound.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';


export function TranslateHttpLoaderFactory(http: HttpClient) {
   return new TranslateHttpLoader(http, 'assets/i18n/', '.json');
}

@NgModule({
   declarations: [
      AppComponent,
      NotfoundComponent,
      UnauthorizedComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      MaterialModule,
      UnprotectedModule,
      ProtectedModule,
      HttpClientModule,
      ServiceWorkerModule.register('ngsw-worker.js', { enabled: true }),
      TranslateModule.forRoot({
         defaultLanguage: 'en',
         loader: {
            provide: TranslateLoader,
            useFactory: TranslateHttpLoaderFactory,
            deps: [HttpClient]
         }
      })
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
