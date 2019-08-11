import { Constants } from '../constants';

export class GeneratorView {

  public get inputSelectorElem(): HTMLElement | null {
    return document.getElementById( Constants.Ids.Generator.inputSelector );
  }

  public get inputSelectorValue(): string | null {
    const inputSelectorElem = this.inputSelectorElem;

    if ( inputSelectorElem )
      return inputSelectorElem.nodeValue;

    return null
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
