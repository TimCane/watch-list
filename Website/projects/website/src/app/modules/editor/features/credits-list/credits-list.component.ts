import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';

@Component({
  selector: 'editor-credits-list',
  templateUrl: './credits-list.component.html',
  styleUrls: ['./credits-list.component.scss'],
})
export class CreditsListComponent implements OnInit {
  constructor(private store: Store<AppState>, private router: Router) {}

  ngOnInit(): void {}

  onNewCredit() {
    this.router.navigate(['/', 'editor', 'credits', 'new']);
  }
}
