import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-back-button',
  imports: [CommonModule],
  templateUrl: './back-button.component.html',
  styleUrls: ['./back-button.component.scss'],
  standalone: true,
})
export class BackButtonComponent {
  @Input() containerClass: string = '';

  @Input() iconClass: string = '';

  @Output() clicked = new EventEmitter<void>();

  public onClick(): void {
    this.clicked.emit();
  }
}
