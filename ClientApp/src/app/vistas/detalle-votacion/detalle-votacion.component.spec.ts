import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalleVotacionComponent } from './detalle-votacion.component';

describe('DetalleVotacionComponent', () => {
  let component: DetalleVotacionComponent;
  let fixture: ComponentFixture<DetalleVotacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalleVotacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalleVotacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
