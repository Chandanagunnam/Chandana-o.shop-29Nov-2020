import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompareproductsComponent } from './compareproducts.component';

describe('CompareproductsComponent', () => {
  let component: CompareproductsComponent;
  let fixture: ComponentFixture<CompareproductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompareproductsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompareproductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
