import { Injectable } from '@angular/core';

import {
  MatSnackBar,
  MatSnackBarRef,
  SimpleSnackBar,
} from '@angular/material/snack-bar';

export enum DurationEnum {
  Short = 1,
  Medium = 2,
  Long = 3,
}

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private openShort = 2000;
  private openMedium = 3500;
  private openLong = 5000;
  constructor(private snackBar: MatSnackBar) {}

  public showConfirmationNotification(message: string): void {
    this.open(message, DurationEnum.Short);
  }

  public openAndReturnSnackbar(
    message: string,
    action: string
  ): MatSnackBarRef<SimpleSnackBar> {
    return this.open(message, DurationEnum.Medium, action);
  }

  public dismiss(): void {
    this.snackBar.dismiss();
  }

  private open(
    message: string,
    duration: DurationEnum,
    action?: string
  ): MatSnackBarRef<SimpleSnackBar> {
    switch (duration) {
      case DurationEnum.Short:
        return this.snackBar.open(message, action, {
          duration: this.openShort,
        });
      case DurationEnum.Medium:
        return this.snackBar.open(message, action, {
          duration: this.openMedium,
        });
      case DurationEnum.Long:
        return this.snackBar.open(message, action, { duration: this.openLong });
    }
  }
}
