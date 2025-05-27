import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-simple-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './simple-form.component.html',
})
export class SimpleFormComponent {
  user = {
    name: '',
    email: ''
  };

  submitted = false;

  submitForm() {
    this.submitted = true;
    console.log('Form Data:', this.user);
  }
}
