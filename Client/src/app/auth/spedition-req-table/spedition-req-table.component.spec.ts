import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpeditionReqTableComponent } from './spedition-req-table.component';

describe('SpeditionReqTableComponent', () => {
  let component: SpeditionReqTableComponent;
  let fixture: ComponentFixture<SpeditionReqTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SpeditionReqTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SpeditionReqTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
