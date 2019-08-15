/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */


import { HttpClient } from '../httpClient';

export class GeneratorService {

  public async compile( input: string | null ): Promise<any> {
    if ( !input )
      null;

    let res = await HttpClient.post( 'api/generator/XMLStringToCSharp', { XML: input } );

    if ( res.ok )
      return await res.json();

    return JSON.stringify( await res.json() );
  }

}
