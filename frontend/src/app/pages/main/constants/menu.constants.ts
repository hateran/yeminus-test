import { RoutesEnum } from '../enums';
import { IMenu } from '../interfaces';

export const MENU: IMenu[] = [
  {
    title: 'Ejercicio encriptación',
    description: 'Recibe una palabra y la encripta usando el algoritmo dado',
    route: RoutesEnum.ENCRYPT,
    styles: {
      color: '#32a6ff',
      gradient: {
        color1: '#2eadff',
        color2: '#3d83ff',
        color3: '#7e61ff',
      },
    },
  },
  {
    title: 'Ejercicio fibonacci',
    description:
      'Recibe un número X y retorna si pertenece o no a la serie de Fibonacci',
    route: RoutesEnum.FIBONACCI,
    styles: {
      color: '#10b981',
      gradient: {
        color1: '#34d399',
        color2: '#10b981',
        color3: '#059669',
      },
    },
  },
  {
    title: 'Ejercicio almacen',
    description: 'Contiene varias opciones para el ejercicio del almacen',
    route: RoutesEnum.STORE,
    styles: {
      color: '#9333ea',
      gradient: {
        color1: '#9333ea',
        color2: '#7e22ce',
        color3: '#6b21a8',
      },
    },
  },
];

export const ROUTES_TO_HIDE_BACK_BTN = [RoutesEnum.MAIN];
