import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
import { Login } from '../../interfaces/Auth/login';
import { Register } from '../../interfaces/Auth/register';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  toggleForm: boolean = false;
  isLoading = false;
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

  loginObj: Login = {
    username: '',
    password: ''
  }


  public onRegister() {
    this.authService.register(this.registerObj).subscribe({
      next: (res) => {
        console.log('Registered Success!', res);
      },
      error: (err) => {
        console.error('Register error!', err)
      }
    });
  }

  public onLogin() {
    this.authService.login(this.loginObj).subscribe({
      next: (res) => {
        this.isLoading = true;

        setTimeout(() => {
          this.isLoading = false;
          localStorage.setItem('token', res.token),
            
          console.log('Logged in!', res);
          this.router.navigateByUrl('/generator')
        }, 1000);
      },
      error: (err) => {
        alert("Username not found and/or password");
        console.error('Login error', err)
      }
    })
  }


}
