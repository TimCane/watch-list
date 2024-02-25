import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { PageHeaderComponent } from './page-header.component';

import { BreadcrumbModule } from 'primeng/breadcrumb';
@NgModule({
  declarations: [PageHeaderComponent],
  imports: [CommonModule, BreadcrumbModule],
  exports: [PageHeaderComponent],
})
export class PageHeaderModule {}
