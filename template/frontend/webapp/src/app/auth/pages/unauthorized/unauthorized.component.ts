import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-unauthorized',
  standalone: false,
  templateUrl: './unauthorized.component.html',
  styleUrl: './unauthorized.component.css'
})
export class UnauthorizedComponent {
  constructor(private location: Location) {}

  goBack(): void {
    this.location.back(); 
  }
}
