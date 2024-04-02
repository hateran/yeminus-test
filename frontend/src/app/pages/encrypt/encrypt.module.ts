import { EncryptComponent } from './encrypt.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EncryptRoutingModule } from './encrypt-routing.module';

@NgModule({
  declarations: [EncryptComponent],
  imports: [CommonModule, EncryptRoutingModule],
})
export class EncryptModule {}
