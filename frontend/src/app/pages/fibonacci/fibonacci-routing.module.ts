import { RouterModule, Routes } from '@angular/router';
import { FibonacciComponent } from './fibonacci.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  {
    path: '',
    component: FibonacciComponent,
  },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
  })
  export class FibonacciRoutingModule {}
