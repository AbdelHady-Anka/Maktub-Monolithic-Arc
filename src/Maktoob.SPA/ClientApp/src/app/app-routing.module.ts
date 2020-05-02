import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotfoundComponent } from './notfound/notfound.component';
import { AuthGuard } from './core/guards/auth.guard';
import { UnauthGuard } from './core/guards/unauth.guard';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () =>
      import('./unprotected/unprotected.module').then(
        (m) => m.UnprotectedModule
      ),
    canLoad: [UnauthGuard]
  },
  {
    path: 'notfound',
    component: NotfoundComponent
  },
  {
    path: 'unauth',
    component: UnauthorizedComponent
  },
  {
    path: '',
    loadChildren: () =>
      import('./protected/protected.module').then(
        (m) => m.ProtectedModule
      ),
    canLoad: [AuthGuard],
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: 'notfound',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, /* { enableTracing: true } */ )],
  exports: [RouterModule],
})
export class AppRoutingModule { }
