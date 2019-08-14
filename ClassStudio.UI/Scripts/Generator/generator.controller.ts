
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

  private addListeners(): void {
    const compileBtnElem = this.view.compileBtnElem;

    if ( !compileBtnElem )
      return;

    compileBtnElem.addEventListener( 'click', async ( e: MouseEvent ) => {
      const inputType = this.view.inputSelectorValue;
      const outputType = this.view.outputSelectorValue;
      const inputCode = this.view.inputElemValue;
      const outputElem = this.view.outputElem;

      if ( outputElem )
        await this.service.compile( inputCode );

      return false;

    } );
  }
}
