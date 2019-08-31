/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */


import { HttpClient } from '../httpClient';
import { LangEnum } from '../Enums/LangEnum';

export class GeneratorService {


  // #region PROPERTIES

  private get baseApiPath(): string {
    return 'api/generator/';
  };

  // #endregion PROPERTIES


  // #region PUBLIC METHODS

  public async compile( inputCode: string | null, inputType: number | null, outputType: number | null ): Promise<any> {
    if ( !inputCode || !inputType || !outputType )
      return "[INPUT NOT VALID]";

    let res: Response;

    if ( inputType == LangEnum.XML && outputType == LangEnum.CSharp ) {
      res = await this.postInputToServer('XMLStringToCSharp', inputCode );

    } else if ( inputType == LangEnum.CSharp && outputType == LangEnum.TypeScript ) {
      res = await this.postInputToServer('CSharpToTypescript', inputCode );

    } else {
      return "[NOT IMPLEMENTED]";
    }

    if ( res.ok )
      return await res.json();

    return JSON.stringify( await res.json() );
  }

  // #endregion METHODS


  // #region PRIVATE METHODS

  private async postInputToServer( endpoint: string, input: string ): Promise<Response> {
    return await HttpClient.post( this.baseApiPath + endpoint, { Input: input } );
  }

  // #endregion PRIVATE METHODS

}
