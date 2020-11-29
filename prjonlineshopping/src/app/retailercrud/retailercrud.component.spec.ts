import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetailercrudComponent } from './retailercrud.component';

describe('RetailercrudComponent', () => {
  let component: RetailercrudComponent;
  let fixture: ComponentFixture<RetailercrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RetailercrudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RetailercrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
