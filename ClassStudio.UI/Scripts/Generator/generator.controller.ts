
import { GeneratorView } from './generator.view';

export class GeneratorController {

  constructor() {
    this.view = new GeneratorView();
    this.addListeners();
  }

  view: GeneratorView;

  private addListeners(): void {
    const compileBtnElem = this.view.compileBtnElem;

    if ( !compileBtnElem )
      return;

    compileBtnElem.addEventListener( 'click', ( e: MouseEvent ) => {
      const inputType = this.view.inputSelectorValue;
      const outputType = this.view.outputSelectorValue;
    } );
  }
}
