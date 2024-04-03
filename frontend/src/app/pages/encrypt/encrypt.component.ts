import {
  Component,
  OnDestroy,
  OnInit,
  TemplateRef,
  ViewChild,
  inject,
} from '@angular/core';
import { OPTIONS } from './constants';
import { IOption } from './interfaces';
import { TemplateEnum } from './enums';
import { EncryptService } from './services/encrypt.service';
import { EncryptFormType } from './types';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-encrypt',
  templateUrl: './encrypt.component.html',
  styleUrls: ['./encrypt.component.scss'],
})
export class EncryptComponent implements OnInit, OnDestroy {
  @ViewChild('encrypt') encryptTemplate!: TemplateRef<any>;

  public form!: EncryptFormType;

  private fb = inject(NonNullableFormBuilder);

  private encryptService = inject(EncryptService);

  private readonly _$unSubscribeSignal = new Subject<void>();

  public ngOnInit(): void {
    this.form = this.fb.group({
      phrase: ['', Validators.required],
      a: [0, [Validators.required, Validators.min(1)]],
      b: [0, [Validators.required, Validators.min(1)]],
      result: [''],
    });
  }

  public ngOnDestroy(): void {
    this.form.reset();
    this.setInactive();
    this._$unSubscribeSignal.next();
    this._$unSubscribeSignal.unsubscribe();
  }

  public getTemplate({ template }: IOption): TemplateRef<any> | null {
    if (template)
      if (template === TemplateEnum.ENCRYPT) return this.encryptTemplate;
    return null;
  }

  public setInactive(): void {
    if (this.activeItem) {
      this.form.reset();
      this.activeItem.isActive = false;
    }
  }

  public encryptText(): void {
    const { result, ...rest } = this.form.getRawValue();
    this.encryptService
      .encrypt(rest)
      .pipe(takeUntil(this._$unSubscribeSignal.asObservable()))
      .subscribe({
        next: (response) => {
          this.form.controls.result.setValue(response);
        },
        error: () => {
          this.form.controls.result.setValue('');
        },
      });
  }

  public get options(): IOption[] {
    return OPTIONS;
  }

  private get activeItem(): IOption | undefined {
    return this.options.find((element) => element.isActive);
  }

  public get showBackBtn(): boolean {
    return Boolean(this.activeItem);
  }
}
