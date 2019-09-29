/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

export class Utils {
  constructor() {
    throw new Error( 'Can not instantiate a static class.' );
  }

  public static isNullOrEmpty( value: string | null | undefined ) {
    return value === null || value === undefined || value === '';
  }

  public static isNullNmbr( value: number | null | undefined ) {
    return value === null || value === undefined;
  }

}
