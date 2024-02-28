import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { LanguageDetailEditFormModule } from './language-detail-edit-form/language-detail-edit-form.module';
import { LanguageDetailRoutingModule } from './language-detail-routing.module';
import { LanguageDetailComponent } from './language-detail.component';

@NgModule({
  declarations: [LanguageDetailComponent],
  imports: [
    CommonModule,
    LanguageDetailRoutingModule,
    ActionBarModule,
    LanguageDetailEditFormModule,
  ],
})
export class LanguageDetailModule {}
