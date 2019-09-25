/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

import { Component, OnInit } from '@angular/core';

import { SelectViewModel, OptionViewModel } from '../../models/select.viewModel';
import { Utils } from 'src/app/shared/Utils';
import { LangType } from '../../enums/LangType';

@Component({
  selector: 'app-generator',
  templateUrl: './generator.component.html',
  styleUrls: ['./generator.component.scss']
})
export class GeneratorComponent implements OnInit {

  __inputSelectViewModel: SelectViewModel;
  __outputSelectViewModel: SelectViewModel;

  inputType: string;
  outputType: string;
  outputCode: string = '';

  constructor() {

    this.__inputSelectViewModel = new SelectViewModel(
      [
        new OptionViewModel( 'XML', LangType.XML.toString() ),
        new OptionViewModel( 'C#', LangType.CSharp.toString() ),
      ]
    );

    this.inputType = this.__inputSelectViewModel.options[0].value;

    this.__outputSelectViewModel = new SelectViewModel(
      [
        new OptionViewModel( 'C#', LangType.XML.toString() ),
        new OptionViewModel( 'TypeScript', LangType.CSharp.toString() ),
      ]
    );

    this.outputType = this.__outputSelectViewModel.options[0].value;

  }

  ngOnInit() {
  }

  /**
   *
   * @param selectType ( "input" | "output" )
   * @param inputType
   */
  onSelect(selectType: string, value: string) {
    selectType = selectType.toUpperCase();

    if (selectType === 'INPUT') {
      this.inputType = value;

    } else if (selectType === "OUTPUT") {
      this.outputType = value;

    } else {
      const exceptionMessage: string = "Unknown generator select type.";
      this.outputCode = exceptionMessage;
      throw new Error( exceptionMessage );
    }

    this.outputCode = `[ GeneratorComponent.onSelect() -> value = ${value} ]`;
  }

  compile() {
    const inputCode: string = (<HTMLInputElement>document.getElementById('input-code')).value;

    if (Utils.isNullOrEmpty(inputCode)) {
      this.outputCode = '[ ERROR: NO INPUT GIVEN ]';

    } else {
      this.outputCode = inputCode;
    }
  }

}
