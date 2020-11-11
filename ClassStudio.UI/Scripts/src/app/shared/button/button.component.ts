/*
 * Copyright (c) 2019-2020 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GPLv3.0 license (GNU General Public License v3.0),
 * located in the root of this project, under the name "LICENSE.md".
 *
 */

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ButtonViewModel } from '../../models/button.viewModel';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {

  @Input() buttonViewModel: ButtonViewModel = new ButtonViewModel(
    '',
    () => { return false; }
  );

  @Output() clicked = new EventEmitter();

  classes: string;

  constructor() {
    this.classes = 'uk-button uk-button-default';
  }

  ngOnInit() {
  }

  onClick(event: Event): any {
    event.preventDefault();
    this.clicked.emit( this.buttonViewModel.onClick( event ) );
  }

}
