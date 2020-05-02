import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProtectedRoutingModule } from './protected-routing.module';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from '../shared/material.module';
import { AccountModule } from './account/account.module';
import { RegisterComponent } from '../unprotected/register/register.component';


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    ProtectedRoutingModule,
    MaterialModule,
    AccountModule
  ]
})
export class ProtectedModule { }
