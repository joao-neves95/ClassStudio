/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { SelectDirectoryDTO } from '../models/DTO/selectDirectoryDTO';

@Injectable({
  providedIn: 'root'
})
export class ElectronService {

    // #region PROPERTIES

    private readonly baseElectronUrl: string = 'api/electron/';
    private readonly selectDirEndpointUrl: string = 'SelectDirectory';

    private httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json;charset=UTF-8',
        'Accept': 'application/json, text/plain'
      } )
    };

    // #endregion PROPERTIES

  constructor( private http: HttpClient ) { }

  selectDirectory(): Observable<string[]> {
    return this.postSelectDirectory( new SelectDirectoryDTO() );
  }

  selectFiles(): Observable<string[]> {
    return this.postSelectDirectory( new SelectDirectoryDTO( false ) );
  }

  private postSelectDirectory( selectDirectoryDTO: SelectDirectoryDTO ): Observable<string[]> {
    return this.http.post<string[]>( this.baseElectronUrl + this.selectDirEndpointUrl, selectDirectoryDTO, this.httpOptions );
  }

}
