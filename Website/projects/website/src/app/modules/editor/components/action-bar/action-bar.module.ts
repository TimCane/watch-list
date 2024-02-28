import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { ActionBarComponent } from './action-bar.component';

@NgModule({
  declarations: [ActionBarComponent],
  imports: [CommonModule, ButtonModule, ToolbarModule],
  exports: [ActionBarComponent],
})
export class ActionBarModule {}
