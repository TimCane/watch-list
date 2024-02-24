import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { KeywordsListRoutingModule } from './keywords-list-routing.module';
import { KeywordsListComponent } from './keywords-list.component';


@NgModule({
  declarations: [
    KeywordsListComponent
  ],
  imports: [
    CommonModule,
    KeywordsListRoutingModule
  ]
})
export class KeywordsListModule { }
