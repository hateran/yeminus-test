import { FibonacciComponent } from './fibonacci.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FibonacciRoutingModule } from './fibonacci-routing.module';
import { BackButtonComponent, CardComponent } from '../../lib';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FibonacciService } from './services/fibonacci.service';

@NgModule({
  declarations: [FibonacciComponent],
  imports: [
    CommonModule,
    FibonacciRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BackButtonComponent,
    CardComponent,
  ],
  providers: [FibonacciService]
})
export class FibonacciModule {}
