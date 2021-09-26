import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { BookResourceRequest } from '../../models';
import { BookingApiService } from '../../services/booking-api.service';

@Component({
  selector: 'app-book-resource-dialog',
  templateUrl: './book-resource-dialog.component.html',
  styleUrls: ['./book-resource-dialog.component.css']
})
export class BookResourceDialogComponent implements OnInit {
  public resourceUid: string;
  public quantityFormControl = new FormControl(0, [Validators.required]);
  public startDateFormControl = new FormControl(new Date(), [Validators.required]);
  public endDateFormControl = new FormControl(new Date(), [Validators.required]);
  public form: FormGroup;

  constructor(public dialogRef: MatDialogRef<BookResourceDialogComponent>, private api: BookingApiService) {
    this.form = new FormGroup({
      quantity: this.quantityFormControl,
      startDate: this.startDateFormControl,
      endDate: this.endDateFormControl
    });
  }

  ngOnInit(): void {}

  public bookResource(): void {
    this.api
      .bookResource(
        this.resourceUid,
        new BookResourceRequest(this.startDateFormControl.value, this.endDateFormControl.value, this.quantityFormControl.value)
      )
      .subscribe(
        (x) => this.dialogRef.close(),
        (err) => this.dialogRef.close()
      );
  }
}
