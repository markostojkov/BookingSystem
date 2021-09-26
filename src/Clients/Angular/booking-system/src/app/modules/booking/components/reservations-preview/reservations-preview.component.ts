import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ResourceViewModel } from '../../models';
import { BookingApiService } from '../../services/booking-api.service';
import { BookingDialogService } from '../../services/booking-dialog.service';

@Component({
  selector: 'app-reservations-preview',
  templateUrl: './reservations-preview.component.html',
  styleUrls: ['./reservations-preview.component.css'],
})
export class ReservationsPreviewComponent implements OnInit {
  public dataSource$: Observable<ResourceViewModel[]>;
  public displayedColumns: string[] = ['name', 'quantity', 'bookButton'];

  constructor(
    private api: BookingApiService,
    private dialog: BookingDialogService
  ) {}

  ngOnInit(): void {
    this.dataSource$ = this.api.getResources();
  }

  public openResourceForBooking(resourceUid: string): void {
    this.dialog.bookResource(resourceUid);
  }
}
