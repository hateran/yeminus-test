import { TemplateEnum } from "../enums";

export interface IOption {
  title: string;
  template?: TemplateEnum;
  disabled: boolean;
  isActive: boolean;
}
