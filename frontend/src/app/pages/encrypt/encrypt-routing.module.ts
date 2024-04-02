import { RouterModule, Routes } from '@angular/router';
import { EncryptComponent } from './encrypt.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  {
    path: '',
    component: EncryptComponent,
  },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
  })
  export class EncryptRoutingModule {}
