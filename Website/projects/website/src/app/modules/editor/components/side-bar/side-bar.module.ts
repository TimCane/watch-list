import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { ImageModule } from 'primeng/image';
import { InputTextModule } from 'primeng/inputtext';
import { PanelMenuModule } from 'primeng/panelmenu';
import { SideBarComponent } from './side-bar.component';

@NgModule({
  declarations: [SideBarComponent],
  imports: [
    CommonModule,
    ImageModule,
    PanelMenuModule,
    InputTextModule,
    ButtonModule,
  ],
  exports: [SideBarComponent],
})
export class SideBarModule {}
