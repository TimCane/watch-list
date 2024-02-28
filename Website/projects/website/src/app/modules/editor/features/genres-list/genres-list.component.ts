import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';

@Component({
  selector: 'editor-genres-list',
  templateUrl: './genres-list.component.html',
  styleUrls: ['./genres-list.component.scss'],
})
export class GenresListComponent implements OnInit {
  constructor(private store: Store<AppState>, private router: Router) {}

  ngOnInit(): void {}

  onNewGenre() {
    this.router.navigate(['/', 'editor', 'genres', 'new']);
  }
}
