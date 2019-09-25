/*
 * Copyright (c) 2019 João Pedro Martins Neves (shivayl) - All Rights Reserved.
 *
 * ClassStudio is licensed under the GNU Lesser General Public License (LGPL),
 * version 3, located in the root of this project, under the name "LICENSE.md".
 *
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GeneratorComponent } from 'src/app/pages/generator/generator.component';
import { AboutComponent } from 'src/app/pages/about/about.component';

const routes: Routes = [
  { path: '', redirectTo: '/generator', pathMatch: 'full' },
  { path: 'generator', component: GeneratorComponent },
  { path: 'about', component: AboutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
