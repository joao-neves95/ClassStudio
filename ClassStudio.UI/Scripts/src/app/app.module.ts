/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule }    from '@angular/common/http';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/header/header.component';
import { GeneratorComponent } from './pages/generator/generator.component';
import { AboutComponent } from './pages/about/about.component';
import { SelectComponent } from './shared/select/select.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    GeneratorComponent,
    AboutComponent,
    SelectComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
