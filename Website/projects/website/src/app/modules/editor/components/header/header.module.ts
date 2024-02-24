import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HeaderComponent } from './header.component';

import { BreadcrumbModule } from 'primeng/breadcrumb';
@NgModule({
  declarations: [HeaderComponent],
  imports: [CommonModule, BreadcrumbModule],
  exports: [HeaderComponent],
})
export class HeaderModule {}
