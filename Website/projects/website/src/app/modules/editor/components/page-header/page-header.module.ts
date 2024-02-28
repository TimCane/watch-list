import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { PageHeaderComponent } from './page-header.component';

import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ButtonModule } from 'primeng/button';
@NgModule({
  declarations: [PageHeaderComponent],
  imports: [CommonModule, BreadcrumbModule, ButtonModule],
  exports: [PageHeaderComponent],
})
export class PageHeaderModule {}
