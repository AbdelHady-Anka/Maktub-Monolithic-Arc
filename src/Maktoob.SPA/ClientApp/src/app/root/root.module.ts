import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RootRoutingModule } from './root-routing.module';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from '../shared/material.module';
import { AccountModule } from './account/account.module';
import { NavComponent } from './nav/nav.component';
import { RootComponent } from './root.component';


@NgModule({
  declarations: [
    HomeComponent,
    NavComponent,
    RootComponent
  ],
  imports: [
    CommonModule,
    RootRoutingModule,
    MaterialModule,
    AccountModule
  ]
})
export class RootModule { }
