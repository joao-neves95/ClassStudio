/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

import { Component, OnInit } from '@angular/core';

import { GeneratorService } from '../../services/generator.service';
import { ElectronService } from '../../services/electron.service';

import { Utils } from 'src/app/shared/utils';
import { SelectViewModel, OptionViewModel } from '../../models/select.viewModel';
import { ButtonViewModel } from '../../models/button.viewModel';
import { LangType } from '../../enums/LangType';
import { InOutSourceType } from '../../enums/InOutSourceType';
import { SelectTypeConstants } from '../../enums/SelectTypeConstants';

@Component( {
  selector: 'app-generator',
  templateUrl: './generator.component.html',
  styleUrls: ['./generator.component.scss']
} )
export class GeneratorComponent implements OnInit {

  // #region PROPERTIES

  __inputSelectViewModel: SelectViewModel;
  __inputSourceSelectViewModel: SelectViewModel;
  __inputSourceButtonViewModel: ButtonViewModel;
  __outputSelectViewModel: SelectViewModel;
  __outputSourceSelectViewModel: SelectViewModel;

  inputType: string;
  inputSourceType: string;
  inputSourcePaths: string[] = [];
  outputType: string;
  outputSourceType: string;
  outputSource: string[] = [];
  outputCode: string = '';

  get InOutSourceEnum() { return InOutSourceType; }

  // #endregion PROPERTIES

  // #region CONSTRUCTOR

  constructor( private generatorService: GeneratorService, private electronService: ElectronService ) {

    this.__inputSelectViewModel = new SelectViewModel(
      [
        new OptionViewModel( 'XML', LangType.XML.toString() ),
        new OptionViewModel( 'JSON', LangType.JSON.toString() ),
        new OptionViewModel( 'C#', LangType.CSharp.toString() ),
      ]
    );
    this.inputType = this.__inputSelectViewModel.options[0].value;

    this.__inputSourceSelectViewModel = new SelectViewModel(
      [
        new OptionViewModel( 'Text', InOutSourceType.Text.toString() ),
        new OptionViewModel( 'File', InOutSourceType.Files.toString() ),
        new OptionViewModel( 'Directory', InOutSourceType.Directory.toString() )
      ]
    );
    this.inputSourceType = this.__inputSourceSelectViewModel.options[0].value;

    this.__inputSourceButtonViewModel = new ButtonViewModel( 'Select', ( e: Event ) => {
      e.preventDefault();
      return this.selectFiles();
    } );

    this.__outputSelectViewModel = new SelectViewModel(
      [
        new OptionViewModel( 'C#', LangType.CSharp.toString() ),
        new OptionViewModel( 'TypeScript', LangType.TypeScript.toString() ),
      ]
    );
    this.outputType = this.__outputSelectViewModel.options[0].value;

    this.__outputSourceSelectViewModel = new SelectViewModel(
      [
        new OptionViewModel( 'Text', InOutSourceType.Text.toString() ),
        new OptionViewModel( 'Directory', InOutSourceType.Directory.toString() )
      ]
    );
    this.outputSourceType = this.__inputSourceSelectViewModel.options[0].value;

  }

  // #endregion CONSTRUCTOR

  ngOnInit() {
  }

  /**
   *
   * @param selectType ( "input" | "output" )
   * @param value
   */
  onSelect( selectType: string, value: string ) {
    selectType = selectType.toUpperCase();

    if ( selectType === SelectTypeConstants.InputCode ) {
      this.inputType = value;

    } else if ( selectType === SelectTypeConstants.OutputCode ) {
      this.outputType = value;

    } else if ( selectType === SelectTypeConstants.InputSource ) {
      this.inputSourceType = value;

    } else if ( selectType === SelectTypeConstants.OutputSource ) {
      this.outputSourceType = value;

    } else {
      const exceptionMessage: string = 'Unknown generator select type.';
      this.outputCode = exceptionMessage;
      throw new Error( exceptionMessage );
    }

  }

  removeFile( index: number ) {
    this.inputSourcePaths.splice( index, 1 );
  }

  selectFiles() {
    if ( this.inputSourceType === this.InOutSourceEnum.Files.toString() ) {
      this.electronService.selectFiles().subscribe( files => { this.inputSourcePaths = files; } );

    } else if ( this.inputSourceType === this.InOutSourceEnum.Directory.toString() ) {
      this.electronService.selectDirectory().subscribe( files => { this.inputSourcePaths = files; } );
    }

  }

  compile() {
    if ( this.inputSourceType === this.InOutSourceEnum.Text.toString() ) {
      const inputCode: string = ( document.getElementById( 'input-code' ) as HTMLInputElement ).value;

      if ( Utils.isNullOrEmpty( inputCode ) ) {
        this.outputCode = '[ ERROR: NO INPUT GIVEN ]';
      }

      this.generatorService.compile( inputCode, parseInt( this.inputType ), parseInt( this.outputType ) )
        .subscribe( output => { this.outputCode = output; } );

    } else if ( this.inputSourceType === this.InOutSourceEnum.Files.toString()
      ||
      this.inputSourceType === this.InOutSourceEnum.Directory.toString()
    ) {
      this.generatorService
        .compileFiles(
          this.inputSourcePaths,
          this.inputSourceType === this.InOutSourceEnum.Files.toString(),
          parseInt( this.inputType ), parseInt( this.outputType )
        )
        .subscribe( output => { this.outputCode = output; } );
    }
  }

}
