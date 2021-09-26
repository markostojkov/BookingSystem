import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { BookResourceDialogComponent } from '../components/book-resource-dialog/book-resource-dialog.component';

@Injectable({
  providedIn: 'root',
})
export class BookingDialogService {
  constructor(private dialog: MatDialog) {}

  public bookResource(resourceUid: string): Observable<any> {
    let dialogRef: MatDialogRef<BookResourceDialogComponent>;
    dialogRef = this.dialog.open(BookResourceDialogComponent, {
      width: '650px',
      height: 'auto',
    });

    dialogRef.componentInstance.resourceUid = resourceUid;

    return dialogRef.afterClosed();
  }
}
