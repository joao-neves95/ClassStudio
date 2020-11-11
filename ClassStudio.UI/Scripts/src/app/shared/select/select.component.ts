/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { SelectViewModel, OptionViewModel } from '../../models/select.viewModel';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.scss']
})
export class SelectComponent implements OnInit {

  @Input() selectViewModel: SelectViewModel = new SelectViewModel( [] );
  @Output() selected = new EventEmitter<string>();

  constructor() {}

  ngOnInit() {
  }

  onSelect(value: string) {
    this.selected.emit( value );
  }

}
