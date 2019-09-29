/*
 * Copyright (c) 2019 Jo�o Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

import { Component, OnInit } from '@angular/core';

import { GeneratorService } from './generator.service';

import { Utils } from 'src/app/shared/utils';
import { SelectViewModel, OptionViewModel } from '../../models/select.viewModel';
import { LangType } from '../../enums/LangType';

@Component({
  selector: 'app-generator',
  templateUrl: './generator.component.html',
  styleUrls: ['./generator.component.scss']
})
export class GeneratorComponent implements OnInit {

  // #region PROPERTIES

  __inputSelectViewModel: SelectViewModel;
  __outputSelectViewModel: SelectViewModel;

  inputType: string;
  outputType: string;
  outputCode: string = '';

  // #endregion PROPERTIES

  // #region CONSTRUCTOR

  constructor( private generatorService: GeneratorService) {

    this.__inputSelectViewModel = new SelectViewModel(
      [
        new OptionViewModel( 'XML', LangType.XML.toString() ),
        new OptionViewModel( 'C#', LangType.CSharp.toString() ),
      ]
    );

    this.inputType = this.__inputSelectViewModel.options[0].value;

    this.__outputSelectViewModel = new SelectViewModel(
      [
        new OptionViewModel( 'C#', LangType.CSharp.toString() ),
        new OptionViewModel( 'TypeScript', LangType.TypeScript.toString() ),
      ]
    );

    this.outputType = this.__outputSelectViewModel.options[0].value;

  }

  // #endregion CONSTRUCTOR

  ngOnInit() {
  }

  /**
   *
   * @param selectType ( "input" | "output" )
   * @param inputType
   */
  onSelect( selectType: string, value: string ) {
    selectType = selectType.toUpperCase();

    if ( selectType === 'INPUT' ) {
      this.inputType = value;

    } else if ( selectType === 'OUTPUT' ) {
      this.outputType = value;

    } else {
      const exceptionMessage: string = 'Unknown generator select type.';
      this.outputCode = exceptionMessage;
      throw new Error( exceptionMessage );
    }

  }

  compile() {
    const inputCode: string = ( document.getElementById( 'input-code' ) as HTMLInputElement ).value;

    if ( Utils.isNullOrEmpty( inputCode ) ) {
      this.outputCode = '[ ERROR: NO INPUT GIVEN ]';

    } else {
      this.generatorService.compile( inputCode, parseInt( this.inputType ), parseInt( this.outputType ) )
          .subscribe( output => { this.outputCode = output } );
    }
  }

}
