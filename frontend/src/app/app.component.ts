import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { ROUTES_TO_HIDE_BACK_BTN } from './pages/main/constants';
import { RoutesEnum } from './pages/main/enums';
import { BackButtonComponent } from './lib';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, BackButtonComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {
  public canBeRendered: boolean = false;

  public constructor(private readonly router: Router) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.canBeRendered = Boolean(
          !ROUTES_TO_HIDE_BACK_BTN.includes(event.url as RoutesEnum)
        );
      }
    });
  }

  public navigateBack(): void {
    this.router.navigate([RoutesEnum.MAIN]);
  }
}
