import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Register } from '../../interfaces/register';
import { Login } from '../../interfaces/login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [CommonModule,],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  toggleForm : boolean = false;
  router = inject(Router);
  
  authService = inject(AuthService);

  
  registerObj: Register = {
    contactName: '',
    contactAddress: "",
    contactNumber: '',
    accessType: 1,
    emailAddress: '',
    username: '',
    password: '',
    confirmPassword: ''
  }

  loginObj: Login ={
    username: '',
    password: ''
  }


  public onRegister(){
    this.authService.register(this.registerObj).subscribe({
      next:(res) =>{
        console.log('Registered Success!', res);
      },
      error: (err) => {
        console.error('Register error!', err)
      }
    });
  }

  public onLogin(){
    this.authService.login(this.loginObj).subscribe({
      next:(res) =>{
        localStorage.setItem('token',res.token),
        console.log('Logged in!', res);
      },
      error: (err)=>{
        alert("Username not found and/or password");
        console.error('Login error', err)
      }
    })
  }


}
