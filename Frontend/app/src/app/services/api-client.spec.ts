import { TestBed } from '@angular/core/testing';

import { ApiCliente } from './api-cliente';

describe('ApiCliente', () => {
  let service: ApiCliente;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiCliente);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
