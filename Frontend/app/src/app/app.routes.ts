import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Client } from './client/client'

export const routes: Routes = [
    {   path: 'home', component: Home   },
    {   path: 'client', component: Client},
    {   path: '**', redirectTo: 'home', pathMatch: 'full'  }
];
