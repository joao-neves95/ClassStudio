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
import { LangType, langTypeLabelToLangId, numberToLangTypeLabel } from '../../enums/LangType';
import { InOutSourceType } from '../../enums/InOutSourceType';
import { SelectTypeConstants } from '../../enums/SelectTypeConstants';

@Component({
    selector: 'app-generator',
    templateUrl: './generator.component.html',
    styleUrls: ['./generator.component.scss']
})
export class GeneratorComponent implements OnInit {

    // #region PROPERTIES

    private converterMappings: any = {};

    __inputSelectViewModel: SelectViewModel = new SelectViewModel([]);
    __inputSourceSelectViewModel: SelectViewModel;
    __outputSelectViewModel: SelectViewModel = new SelectViewModel([]);
    __outputSourceSelectViewModel: SelectViewModel;
    __inputSourceButtonViewModel: ButtonViewModel;

    inputType: string = '';
    inputSourceType: string = '';
    inputSourcePaths: string[] = [];
    outputType: string = '';
    outputSourceType: string = '';
    outputSource: string[] = [];
    outputCode: string = '';

    get InOutSourceEnum() { return InOutSourceType; }

    // #endregion PROPERTIES

    // #region CONSTRUCTOR

    constructor(private generatorService: GeneratorService, private electronService: ElectronService) {
        this.__inputSourceSelectViewModel = new SelectViewModel(
            [
                new OptionViewModel('Text', InOutSourceType.Text.toString()),
                new OptionViewModel('File', InOutSourceType.Files.toString()),
                new OptionViewModel('Directory', InOutSourceType.Directory.toString())
            ]
        );
        this.inputSourceType = this.__inputSourceSelectViewModel.options[0].value;

        this.__outputSourceSelectViewModel = new SelectViewModel(
            [
                new OptionViewModel('Text', InOutSourceType.Text.toString()),
                new OptionViewModel('Directory', InOutSourceType.Directory.toString())
            ]
        );
        this.outputSourceType = this.__inputSourceSelectViewModel.options[0].value;

        this.__inputSourceButtonViewModel = new ButtonViewModel('Select', (e: Event) => {
            e.preventDefault();
            return this.selectFiles();
        });
    }

    // #endregion CONSTRUCTOR

    async ngOnInit(): Promise<void> {
        this.converterMappings = await this.generatorService.getConverterMappings();

        for (const lang in this.converterMappings) {
            if ((this.converterMappings[lang] as number[]).length === 0) {
                continue;
            }

            this.__inputSelectViewModel.options.push(
                new OptionViewModel(lang, langTypeLabelToLangId(lang).toString() )
            );
        }

        this.inputType = this.__inputSelectViewModel.options[0].value;

        this.onSelect( SelectTypeConstants.InputCode, this.inputType );
    }

    /**
     *
     * @param selectType ( "input" | "output" )
     * @param value
     */
    onSelect(selectType: string, value: string) {
        selectType = selectType.toUpperCase();

        if (selectType === SelectTypeConstants.InputCode) {
            this.inputType = value;
            this.__outputSelectViewModel.options.splice(0);
            this.__outputSelectViewModel.options = this.mapInputLangToOutputViewModels(this.inputType);
            this.outputType = this.__outputSelectViewModel.options[0]?.value;

        } else if (selectType === SelectTypeConstants.OutputCode) {
            this.outputType = value;

        } else if (selectType === SelectTypeConstants.InputSource) {
            this.inputSourceType = value;

        } else if (selectType === SelectTypeConstants.OutputSource) {
            this.outputSourceType = value;

        } else {
            const exceptionMessage = 'Unknown generator select type.';
            this.outputCode = exceptionMessage;
            throw new Error(exceptionMessage);
        }

    }

    private mapInputLangToOutputViewModels(inputLangId: string): OptionViewModel[] {
        const viewModels = [];
        const outputLangsIds = this.converterMappings[ numberToLangTypeLabel(parseInt(inputLangId)) ] as number[] ?? [];

        for (const langOutputId of outputLangsIds) {
            viewModels.push( new OptionViewModel( numberToLangTypeLabel( langOutputId ), langOutputId.toString() ) );
        }

        return viewModels;
    }

    removeFile(index: number) {
        this.inputSourcePaths.splice(index, 1);
    }

    selectFiles() {
        if (this.inputSourceType === this.InOutSourceEnum.Files.toString()) {
            this.electronService.selectFiles().subscribe(files => { this.inputSourcePaths = files; });

        } else if (this.inputSourceType === this.InOutSourceEnum.Directory.toString()) {
            this.electronService.selectDirectory().subscribe(files => { this.inputSourcePaths = files; });
        }

    }

    compile() {
        if (this.inputSourceType === this.InOutSourceEnum.Text.toString()) {
            const inputCode: string = (document.getElementById('input-code') as HTMLInputElement).value;

            if (Utils.isNullOrEmpty(inputCode)) {
                this.outputCode = '[ ERROR: NO INPUT GIVEN ]';
            }

            this.generatorService.compile(inputCode, parseInt(this.inputType), parseInt(this.outputType))
                .subscribe(output => { this.outputCode = output; });

        } else if (this.inputSourceType === this.InOutSourceEnum.Files.toString()
            ||
            this.inputSourceType === this.InOutSourceEnum.Directory.toString()
        ) {
            this.generatorService
                .compileFiles(
                    this.inputSourcePaths,
                    this.inputSourceType === this.InOutSourceEnum.Files.toString(),
                    parseInt(this.inputType), parseInt(this.outputType)
                )
                .subscribe(output => { this.outputCode = output; });
        }
    }

}
