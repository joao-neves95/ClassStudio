/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

export class HttpClient {
  public static async get( url: string ): Promise<Response> {
    return await fetch( url, {
      headers: {
        'Accept': 'application/json, text/plain',
      },
      method: 'GET'
    } );
  }

  public static async post( url: string, data: any ): Promise<Response> {
    return await fetch( url, {
      headers: {
        'Accept': 'application/json, text/plain',
        'Content-Type': 'application/json;charset=UTF-8'
      },
      method: 'POST',
      body: JSON.stringify( data )
    } );
  }
}
