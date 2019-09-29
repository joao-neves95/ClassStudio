/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

import { GeneratorView } from './generator.view';
import { GeneratorService } from './generator.services';

export class GeneratorController {

  constructor() {
    this.view = new GeneratorView();
    this.service = new GeneratorService();
    this.addListeners();
  }

  // #region PROPERTIES

  view: GeneratorView;
  service: GeneratorService;

  // #endregion PROPERTIES

  // #region METHODS

  private addListeners(): void {
    const compileBtnElem = this.view.compileBtnElem;

    if ( !compileBtnElem )
      return;

    compileBtnElem.addEventListener( 'click', async ( e: MouseEvent ) => {

      const inputType = this.view.inputSelectorValue;
      const outputType = this.view.outputSelectorValue;
      const inputCode: string | null = this.view.inputElemValue;
      const outputElem: HTMLInputElement | null = this.view.outputElem;

      if ( !inputCode || !outputElem )
        return false;

      outputElem.value = await this.service.compile( inputCode, Number( inputType ), Number( outputType ) );

    } );
  }

  // #endregion METHODS

}
