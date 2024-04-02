import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./pages/main/main.module').then((m) => m.MainModule),
  },
  {
    path: 'encrypt',
    loadChildren: () =>
      import('./pages/encrypt/encrypt.module').then((m) => m.EncryptModule),
  },
  {
    path: 'fibonacci',
    loadChildren: () =>
      import('./pages/fibonacci/fibonacci.module').then(
        (m) => m.FibonacciModule
      ),
  },
  {
    path: 'store',
    loadChildren: () =>
      import('./pages/store/store.module').then((m) => m.StoreModule),
  },
  {
    path: '**',
    redirectTo: '',
  },
];
