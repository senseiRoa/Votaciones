import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VotacionDetalleComponent } from './votacion-detalle.component';

describe('VotacionDetalleComponent', () => {
  let component: VotacionDetalleComponent;
  let fixture: ComponentFixture<VotacionDetalleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VotacionDetalleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VotacionDetalleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
