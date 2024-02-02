import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransportReqTableComponent } from './transport-req-table.component';

describe('TransportReqTableComponent', () => {
  let component: TransportReqTableComponent;
  let fixture: ComponentFixture<TransportReqTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TransportReqTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TransportReqTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
