/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

import { Injectable, Output } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import { GeneratorDTO } from '../models/DTO/generatorDTO';

import { Constants } from '../constants';
import { Utils } from '../shared/utils';
import { LangType } from '../enums/LangType';

@Injectable( {
  providedIn: 'root'
} )
export class GeneratorService {

  // #region PROPERTIES

  private readonly baseGeneratorUrl: string = 'api/generator/';

  private httpOptions = {
    headers: new HttpHeaders( {
      'Content-Type': 'application/json;charset=UTF-8',
      'Accept': 'application/json, text/plain'
    } )
  };

  // #endregion PROPERTIES

  constructor( private http: HttpClient ) { }

  // #region PUBLIC METHODS

  /**
   * Return E.g.:
   * {
   *   XML: [2],
   *   CSharp: [1, 2],
   * }
   *
   * Same id as in LangType.
   */
  public async getConverterMappings(): Promise<any> {
    const res = await fetch( this.baseGeneratorUrl + 'ConverterMappings' );
    return await res.json();
  }

  /**
   * POST request to compile code in the GeneratorController.
   */
  compile( inputCode: string | null | undefined, inputType: number | null | undefined, outputType: number | null | undefined ): Observable<string> {

    if ( Utils.isNullOrEmpty( inputCode ) ) {
      return of( Constants.ErrorMessages.WrongInput );
    }

    return this.postInputToServer( new GeneratorDTO( inputCode as string ), inputType, outputType );
  }

  compileFiles( inputFiles: string[], inputAreFiles: boolean, inputType: number | null | undefined, outputType: number | null | undefined ) {

    if ( Utils.isNullOrEmptyArr( inputFiles ) ) {
      return of( Constants.ErrorMessages.WrongInput );
    }

    return this.postInputToServer( new GeneratorDTO( null, inputType as number, inputAreFiles, inputFiles ), inputType, outputType );
  }

  // #endregion PUBLIC METHODS

  // #region PRIVATE METHODS

  private postInputToServer( dto: GeneratorDTO, inputType: number | null | undefined, outputType: number | null | undefined ): Observable<string> {

    if ( Utils.isNullNmbr( inputType ) || Utils.isNullNmbr( outputType ) ) {
      return of( Constants.ErrorMessages.WrongInput );
    }

    const endpoint: string = this.parseEndpoint( inputType as number, outputType as number );

    if ( endpoint === '' ) {
      return of( Constants.ErrorMessages.NotImplemented );
    }

    return this.http.post<string>( this.baseGeneratorUrl + endpoint, dto, this.httpOptions );
  }

  // #endregion PRIVATE METHODS

  // #region PRIVATE HELPER METHODS

  private parseEndpoint( inputType: number, outputType: number ): string {

    if ( inputType === LangType.XML && outputType === LangType.CSharp ) {
      return 'XMLStringToCSharp';

    } else if ( inputType === LangType.CSharp && outputType === LangType.TypeScript ) {
      return 'CSharpToTypescript';

    } else if ( inputType === LangType.JSON && outputType === LangType.CSharp ) {
      return 'JsonToCSharp';

    } else {
      return '';
    }

  }

  // #endregion PRIVATE HELPER METHODS
}
