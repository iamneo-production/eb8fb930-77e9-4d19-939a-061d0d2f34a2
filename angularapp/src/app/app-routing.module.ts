import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
<<<<<<< HEAD
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HomeComponent } from './home/home.component';
import { AdminhomeComponent } from './adminhome/adminhome.component';

const routes: Routes = [ {
  path:'',
  redirectTo:'login',
  pathMatch:'full'
},{
  path:'login',
  component:LoginComponent
},
{
  path:'signup',
  component:SignupComponent
},
{
  path: 'UserHome',component:
  HomeComponent
},
{
  path:'adminHome',component: AdminhomeComponent
}];
=======

const routes: Routes = [];
>>>>>>> Ecommerce-HariniVenkat07

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
