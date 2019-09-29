/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

import { Injectable, Output } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { Utils } from '../../shared/utils';
import { LangType } from '../../enums/LangType';

@Injectable({
  providedIn: 'root'
})
export class GeneratorService {

  // #region PROPERTIES

  private readonly baseGeneratorUrl: string = 'api/generator/';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json;charset=UTF-8',
      'Accept': 'application/json, text/plain'
    } )
  };

  // #endregion PROPERTIES

  constructor( private http: HttpClient ) { }

  /**
   * POST request to compile code in the GeneratorController.
   */
  compile( inputCode: string | null | undefined, inputType: number | null | undefined, outputType: number | null | undefined ): Observable<string> {

    if ( Utils.isNullOrEmpty( inputCode ) || Utils.isNullNmbr( inputType ) || Utils.isNullNmbr( outputType ) ) {
      return of( '[ INVALID INPUT ]' );

    } else if ( inputType == LangType.XML && outputType == LangType.CSharp ) {
      return this.postInputToServer( 'XMLStringToCSharp', inputCode as string );

    } else if ( inputType == LangType.CSharp && outputType == LangType.TypeScript ) {
      return this.postInputToServer( 'CSharpToTypescript', inputCode as string );

    } else {
      return of( '[ NOT IMPLEMENTED ]' );
    }

  }

  private postInputToServer( endpoint: string, input: string ): Observable<string> {
    return this.http.post<string>( this.baseGeneratorUrl + endpoint, { Input: input }, this.httpOptions );
  }
}
