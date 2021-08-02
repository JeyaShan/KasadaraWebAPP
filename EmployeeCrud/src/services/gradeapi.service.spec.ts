import { TestBed } from '@angular/core/testing';

import { GradeapiService } from './gradeapi.service';

describe('GradeapiService', () => {
  let service: GradeapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GradeapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
