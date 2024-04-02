import { RouterModule, Routes } from '@angular/router';
import { StoreComponent } from './store.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  {
    path: '',
    component: StoreComponent,
  },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
  })
  export class StoreRoutingModule {}
