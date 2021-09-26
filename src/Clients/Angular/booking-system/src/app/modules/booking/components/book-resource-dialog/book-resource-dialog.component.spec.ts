import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookResourceDialogComponent } from './book-resource-dialog.component';

describe('BookResourceDialogComponent', () => {
  let component: BookResourceDialogComponent;
  let fixture: ComponentFixture<BookResourceDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookResourceDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookResourceDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
