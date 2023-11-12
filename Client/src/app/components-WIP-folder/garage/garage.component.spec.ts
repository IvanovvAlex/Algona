import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageComponent } from './garage.component';

describe('GarageComponent', () => {
  let component: GarageComponent;
  let fixture: ComponentFixture<GarageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GarageComponent]
    });
    fixture = TestBed.createComponent(GarageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
