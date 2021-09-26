import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'reservations',
    loadChildren: () =>
      import('./modules/booking/booking.module').then((x) => x.BookingModule),
  },
  {
    path: '**',
    redirectTo: 'reservations',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
