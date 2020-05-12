import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RondaVotacionVotoComponent } from './ronda-votacion-voto.component';

describe('RondaVotacionVotoComponent', () => {
  let component: RondaVotacionVotoComponent;
  let fixture: ComponentFixture<RondaVotacionVotoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RondaVotacionVotoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RondaVotacionVotoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
