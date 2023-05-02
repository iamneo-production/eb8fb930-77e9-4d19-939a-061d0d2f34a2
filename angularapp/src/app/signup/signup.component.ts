import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { SignupService } from 'src/service/signup.service';
import {ToastrService} from 'ngx-toastr';
export class UserModel{
  Email ! : string; 
 Password ! : string;
 UserName ! : string;
 MobileNumber ! : string;
  role! : string;
}
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit{
  signupForm!: FormGroup;

  constructor(private formBuilder: FormBuilder,public signupservice:SignupService,
    private toastr : ToastrService) {}
  ngOnInit():void{
    this.signupForm = this.formBuilder.group({
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', Validators.required],
      MobileNumber:['',Validators.required],
      UserName: ['', Validators.required],
      role:['',Validators.required]
      });
  }
  onSubmit(): void {
  if(this.signupForm.valid){
    this.signupservice.Create(this.signupForm.value).subscribe(res=>{console.log(res)});
    this.toastr.success("Registered SuccessFully");
    this.signupForm.reset();
  }else{
   //alert('Specify the Values');
   this.toastr.error("Registered Failed");
  }
}
}
