import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { LayoutComponent } from './components/layout/layout.component';
import { HomeComponent } from './components/generator/home.component';
import { authGuard } from './guards/auth.guard';
import { CustomerComponent } from './components/customer/customer.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: '/login',
        pathMatch: 'full',
    },
    {
        path:'login',
        component:LoginComponent
    },
    {
        path:'',
        component:LayoutComponent,
        canActivate:[authGuard],
        children:[
            {
                path:'generator',
                component:HomeComponent,

            },
            {
                path:'customer',
                component:CustomerComponent
            }
           
        ]
    }
   
];
