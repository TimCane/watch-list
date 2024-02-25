import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EditorRoutingModule } from './editor-routing.module';
import { EditorComponent } from './editor.component';

import { PageHeaderModule } from './components/page-header/page-header.module';
import { SideBarModule } from './components/side-bar/side-bar.module';
import { TopBarModule } from './components/top-bar/top-bar.module';

@NgModule({
  declarations: [EditorComponent],
  imports: [
    CommonModule,
    EditorRoutingModule,
    SideBarModule,
    TopBarModule,
    PageHeaderModule,
  ],
})
export class EditorModule {}
