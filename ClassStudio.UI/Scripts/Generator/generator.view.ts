import { Constants } from '../constants';

export class GeneratorView {

  public get inputElem(): HTMLElement | null {
    return document.getElementById( 'input-code' );
  }

  public get inputElemValue(): string | null {
    const inputElem = this.inputElem;

    if ( inputElem )
      return inputElem.nodeValue;

    return null;
  }

  public get inputSelectorElem(): HTMLElement | null {
    return document.getElementById( Constants.Ids.Generator.inputSelector );
  }

  public get inputSelectorValue(): string | null {
    const inputSelectorElem = this.inputSelectorElem;

    if ( inputSelectorElem )
      return inputSelectorElem.nodeValue;

    return null
  }

  public get outputElem(): HTMLElement | null {
    return document.getElementById( 'output-textarea' );
  }

  public get outputElemValue(): string | null {
    const outpuElem = this.outputElem;

    if ( outpuElem )
      return outpuElem.nodeValue;

    return null;
  }

  public get outputSelectorElem(): HTMLElement | null {
    return document.getElementById( Constants.Ids.Generator.outputSelector );
  }

  public get outputSelectorValue(): string | null{
    const outputSelectorElem = this.outputSelectorElem;

    if ( outputSelectorElem )
      return outputSelectorElem.nodeValue;

    return null
  }

  public get compileBtnElem(): HTMLElement | null {
    return document.getElementById( Constants.Ids.Generator.compileBtn );
  }

}
