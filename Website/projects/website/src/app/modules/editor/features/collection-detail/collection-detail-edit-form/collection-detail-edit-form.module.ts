import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { ToolbarModule } from 'primeng/toolbar';
import { InputErrorModule } from '../../../../shared/components/input-error/input-error.module';
import { CollectionDetailEditFormComponent } from './collection-detail-edit-form.component';

@NgModule({
  declarations: [CollectionDetailEditFormComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CardModule,
    InputTextModule,
    InputErrorModule,
    CalendarModule,
    ButtonModule,
    ToolbarModule,
  ],
  exports: [CollectionDetailEditFormComponent],
})
export class CollectionDetailEditFormModule {}
