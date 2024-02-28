import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';

@Component({
  selector: 'editor-languages-list',
  templateUrl: './languages-list.component.html',
  styleUrls: ['./languages-list.component.scss'],
})
export class LanguagesListComponent implements OnInit {
  constructor(private store: Store<AppState>, private router: Router) {}

  ngOnInit(): void {}

  onNewLanguage() {
    this.router.navigate(['/', 'editor', 'languages', 'new']);
  }
}
