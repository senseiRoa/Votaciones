/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NotificationRTService } from './NotificationRT.service';

describe('Service: NotificationRT', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NotificationRTService]
    });
  });

  it('should ...', inject([NotificationRTService], (service: NotificationRTService) => {
    expect(service).toBeTruthy();
  }));
});
