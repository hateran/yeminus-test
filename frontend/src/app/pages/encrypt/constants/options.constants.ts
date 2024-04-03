import { TemplateEnum } from '../enums';
import { IOption } from '../interfaces';

export const OPTIONS: IOption[] = [
  {
    title: 'Encriptar',
    template: TemplateEnum.ENCRYPT,
    disabled: false,
    isActive: false,
  },
  {
    title: 'Desencriptar',
    disabled: true,
    isActive: false,
  },
];
