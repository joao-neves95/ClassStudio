/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

import { Constants } from '../constants';

export class GeneratorView {

  public get inputElem(): HTMLInputElement | null {
    return <HTMLInputElement>document.getElementById( 'input-code' );
  }

  public get inputElemValue(): string | null {
    const inputElem = this.inputElem;

    if ( inputElem )
      return inputElem.value;

    return null;
  }

  public get inputSelectorElem(): HTMLInputElement | null {
    return <HTMLInputElement>document.getElementById( Constants.Ids.Generator.inputSelector );
  }

  public get inputSelectorValue(): string | null {
    const inputSelectorElem = this.inputSelectorElem;

    if ( inputSelectorElem )
      return inputSelectorElem.value;

    return null
  }

  public get outputElem(): HTMLInputElement | null {
    return <HTMLInputElement>document.getElementById( 'output-textarea' );
  }

  public get outputElemValue(): string | null {
    const outpuElem = this.outputElem;

    if ( outpuElem )
      return outpuElem.nodeValue;

    return null;
  }

  public get outputSelectorElem(): HTMLSelectElement | null {
    return <HTMLSelectElement>document.getElementById( Constants.Ids.Generator.outputSelector );
  }

  public get outputSelectorValue(): string | null{
    const outputSelectorElem = this.outputSelectorElem;

    if ( outputSelectorElem )
      return outputSelectorElem.value;

    return null
  }

  public get compileBtnElem(): HTMLElement | null {
    return document.getElementById( Constants.Ids.Generator.compileBtn );
  }

}
