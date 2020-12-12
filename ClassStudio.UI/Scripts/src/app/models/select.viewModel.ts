/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

export class SelectViewModel {

  options: OptionViewModel[];

  constructor( options: OptionViewModel[] ) {
    this.options = options;
  }

}

export class OptionViewModel {

  label: string;
  value: string;

  constructor( label: string, value: string ) {
    this.label = label;
    this.value = value;
  }

}
