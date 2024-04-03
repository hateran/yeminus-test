import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { FibonacciFormType } from './types';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { FibonacciService } from './services/fibonacci.service';

@Component({
  selector: 'app-fibonacci',
  templateUrl: './fibonacci.component.html',
  styleUrls: ['./fibonacci.component.scss'],
})
export class FibonacciComponent implements OnInit, OnDestroy {
  public form!: FibonacciFormType;

  private fb = inject(FormBuilder);

  private fibonacciService = inject(FibonacciService);

  private readonly _$unSubscribeSignal = new Subject<void>();

  public ngOnInit(): void {
    this.form = this.fb.group({
      value: new FormControl(0, {
        nonNullable: true,
        validators: Validators.required,
      }),
      result: new FormControl<boolean | null>(null),
    });
  }

  public ngOnDestroy(): void {
    this.form.reset();
    this._$unSubscribeSignal.next();
    this._$unSubscribeSignal.unsubscribe();
  }

  public validate(): void {
    const { result, ...rest } = this.form.getRawValue();
    this.fibonacciService
      .validate(rest)
      .pipe(takeUntil(this._$unSubscribeSignal.asObservable()))
      .subscribe({
        next: (response) => {
          this.form.controls.result.setValue(response);
        },
        error: () => {
          this.form.controls.result.setValue(false);
        },
      });
  }
}
