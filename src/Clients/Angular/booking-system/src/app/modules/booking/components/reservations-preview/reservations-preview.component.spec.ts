import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservationsPreviewComponent } from './reservations-preview.component';

describe('ReservationsPreviewComponent', () => {
  let component: ReservationsPreviewComponent;
  let fixture: ComponentFixture<ReservationsPreviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReservationsPreviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservationsPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
