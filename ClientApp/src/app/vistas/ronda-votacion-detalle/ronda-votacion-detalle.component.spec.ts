import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RondaVotacionDetalleComponent } from './ronda-votacion-detalle.component';

describe('RondaVotacionDetalleComponent', () => {
  let component: RondaVotacionDetalleComponent;
  let fixture: ComponentFixture<RondaVotacionDetalleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RondaVotacionDetalleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RondaVotacionDetalleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
