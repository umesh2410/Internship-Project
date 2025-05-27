import { Component } from '@angular/core';
import { SimpleFormComponent } from './simple-form/simple-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [SimpleFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Simple Angular Form';
  name = '';
  isNameVisible = false;

  onClick() {
    this.isNameVisible = true;
  }
}
