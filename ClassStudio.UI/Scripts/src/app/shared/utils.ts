/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
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

  public static isNullOrEmptyArr( value: any[] | null | undefined ) {
    return value === null || value === undefined || value.length <= 0;
  }

}
