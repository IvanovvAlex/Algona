import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminRequestPageComponent } from './admin-request-page.component';

describe('AdminRequestPageComponent', () => {
  let component: AdminRequestPageComponent;
  let fixture: ComponentFixture<AdminRequestPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminRequestPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminRequestPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
