/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
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

  constructor() { }

  ngOnInit() {
  }

  onSelect(value: string) {
    this.selected.emit( value );
  }

}
