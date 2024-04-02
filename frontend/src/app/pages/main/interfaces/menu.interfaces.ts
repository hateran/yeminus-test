import { RoutesEnum } from '../enums';

interface Gradient {
  color1: string;
  color2: string;
  color3: string;
}

interface Styles {
  color: string;
  gradient: Gradient;
}

export interface IMenu {
  title: string;
  description?: string;
  route: RoutesEnum;
  styles: Styles;
}
