import { Component, inject } from '@angular/core';
import { IMenu } from './interfaces';
import { MENU } from './constants';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
})
export class MainComponent {
  private readonly router = inject(Router);

  public navigate({ route }: IMenu): void {
    this.router.navigate([route]);
  }

  public get options(): IMenu[] {
    return MENU;
  }
}
