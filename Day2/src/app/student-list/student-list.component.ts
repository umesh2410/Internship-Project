import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.css'
})
export class StudentListComponent {
  students = [
    { id: 1, name: 'John Doe', email: 'john@example.com', course: 'Computer Science' },
    { id: 2, name: 'Jane Smith', email: 'jane@example.com', course: 'Mathematics' },
    { id: 3, name: 'Bob Johnson', email: 'bob@example.com', course: 'Physics' }
  ];
}
