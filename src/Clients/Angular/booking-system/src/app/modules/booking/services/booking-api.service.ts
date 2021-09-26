import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { BaseApiService } from 'src/app/shared-app/services/base-api.service';
import { NotificationService } from 'src/app/shared-app/services/notification.service';
import { BookResourceRequest, ResourceResponse, ResourceViewModel } from '../models';

@Injectable({
  providedIn: 'root'
})
export class BookingApiService extends BaseApiService {
  constructor(private httpService: HttpClient, private notification: NotificationService) {
    super(httpService, notification);
  }

  public getResources(): Observable<ResourceViewModel[]> {
    return this.get<ResourceResponse[]>('resources').pipe(map((x) => x.map((y) => new ResourceViewModel(y.uid, y.name, y.quantity))));
  }

  public bookResource(resourceUid: string, request: BookResourceRequest): Observable<void> {
    return this.post(`resources/${resourceUid}/bookings`, request).pipe(
      catchError((x) => {
        this.handleErrorWithSnackbar(x.error);
        return of(x);
      })
    );
  }
}
