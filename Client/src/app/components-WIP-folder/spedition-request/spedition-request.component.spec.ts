import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpeditionRequestComponent } from './spedition-request.component';

describe('SpeditionRequestComponent', () => {
  let component: SpeditionRequestComponent;
  let fixture: ComponentFixture<SpeditionRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SpeditionRequestComponent]
    });
    fixture = TestBed.createComponent(SpeditionRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
