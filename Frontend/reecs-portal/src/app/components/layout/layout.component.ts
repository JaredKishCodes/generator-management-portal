import { Component,inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-layout',
  imports: [RouterOutlet,CommonModule,
    RouterModule,
    ],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {

  router = inject(Router);

  

  onLogout(){
    localStorage.removeItem('token');
    this.router.navigateByUrl('/login');
  }
}
