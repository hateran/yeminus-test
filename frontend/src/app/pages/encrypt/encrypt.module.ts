import { EncryptComponent } from './encrypt.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EncryptRoutingModule } from './encrypt-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EncryptService } from './services/encrypt.service';
import { HttpClientModule } from '@angular/common/http';
import { BackButtonComponent, CardComponent } from '../../lib';

@NgModule({
  declarations: [EncryptComponent],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    EncryptRoutingModule,
    BackButtonComponent,
    CardComponent,
  ],
  providers: [EncryptService],
})
export class EncryptModule {}
