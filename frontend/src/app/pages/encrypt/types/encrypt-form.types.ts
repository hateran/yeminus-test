import { FormControl, FormGroup } from '@angular/forms';

export type EncryptFormType = FormGroup<{
  phrase: FormControl<string>;
  a: FormControl<number>;
  b: FormControl<number>;
  result: FormControl<string>;
}>;
