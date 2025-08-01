import { Component, signal } from '@angular/core';
import { RouterModule ,RouterOutlet } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';


@Component({
  selector: 'app-root',
  imports: [
    RouterModule,
    RouterOutlet,
    MatSidenavModule
  ],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('app');
}
