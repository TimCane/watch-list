import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EditorRoutingModule } from './editor-routing.module';
import { EditorComponent } from './editor.component';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { PageHeaderModule } from './components/page-header/page-header.module';
import { SideBarModule } from './components/side-bar/side-bar.module';
import { TopBarModule } from './components/top-bar/top-bar.module';
import { EditorEffects } from './state/editor/editor.effect';
import { editorReducer } from './state/editor/editor.reducer';

@NgModule({
  declarations: [EditorComponent],
  imports: [
    CommonModule,
    EditorRoutingModule,
    SideBarModule,
    TopBarModule,
    PageHeaderModule,
    StoreModule.forFeature('editorFeature', editorReducer),
    EffectsModule.forFeature([EditorEffects]),
  ],
})
export class EditorModule {}
