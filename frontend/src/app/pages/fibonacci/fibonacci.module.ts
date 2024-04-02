import { FibonacciComponent } from './fibonacci.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FibonacciRoutingModule } from './fibonacci-routing.module';

@NgModule({
  declarations: [FibonacciComponent],
  imports: [CommonModule, FibonacciRoutingModule],
})
export class FibonacciModule {}
