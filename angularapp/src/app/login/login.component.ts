import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from 'src/service/login.service';
export class LoginModel
{
  Email! : string;
  Password! : string;
}
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  login:LoginModel=new LoginModel();
  constructor(private loginservice:LoginService,public router:Router,private toastr:ToastrService){}
  
  onSubmit(userform:NgForm){
    if(!userform.valid){
      alert("enter valid Email address");
    }
    if(userform.valid){
      console.log("hi this is check");
      console.log(userform.value);
      this.loginservice.Create(userform.value).subscribe(res=>{
        var str=JSON.stringify(res)
        var r=JSON.parse(str)
        if(r.errorMessage=='No user found with username'){
          alert("no user user found");
          //this.toastr.error("Login Failed");
          userform.resetForm();
        }else{
          var role=this.loginservice.settoken(r.message)
          role=role.toLowerCase();
          if(role=="user"){
            this.router.navigateByUrl('product');
            this.toastr.success("Welcome User");
          }else{
            this.router.navigateByUrl('admin');
            this.toastr.success("Welcome");
          }
          userform.resetForm();
        }
        });
      
      
      }
    }

}
