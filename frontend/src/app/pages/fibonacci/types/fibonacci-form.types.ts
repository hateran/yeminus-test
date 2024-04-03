import { FormControl, FormGroup } from '@angular/forms';

export type FibonacciFormType = FormGroup<{
  value: FormControl<number>;
  result: FormControl<boolean | null>;
}>;
