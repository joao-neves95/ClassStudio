/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

import { TestBed } from '@angular/core/testing';

import { ElectronService } from './electron.service';

describe('ElectronService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ElectronService = TestBed.get(ElectronService);
    expect(service).toBeTruthy();
  });
});
