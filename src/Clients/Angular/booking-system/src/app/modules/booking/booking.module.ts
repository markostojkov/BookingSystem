import { NgModule } from '@angular/core';
import { SharedAppModule } from 'src/app/shared-app/shared-app.module';
import { BookingRoutingModule } from './booking.routes';
import { BOOKING_COMPONENTS } from './components/booking-components';
import { BOOKING_COMPONENTS_DIALOG } from './components/booking-components-dialog';

@NgModule({
  declarations: [BOOKING_COMPONENTS, BOOKING_COMPONENTS_DIALOG],
  imports: [SharedAppModule, BookingRoutingModule],
  entryComponents: [BOOKING_COMPONENTS_DIALOG],
})
export class BookingModule {}
