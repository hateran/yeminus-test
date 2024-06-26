import { StoreComponent } from './store.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreRoutingModule } from './store-routing.module';

@NgModule({
  declarations: [StoreComponent],
  imports: [CommonModule, StoreRoutingModule],
})
export class StoreModule {}
