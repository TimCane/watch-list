import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';

@Component({
  selector: 'editor-production-countries-list',
  templateUrl: './production-countries-list.component.html',
  styleUrls: ['./production-countries-list.component.scss'],
})
export class ProductionCountriesListComponent implements OnInit {
  constructor(private store: Store<AppState>, private router: Router) {}

  ngOnInit(): void {}

  onNewProductionCountry() {
    this.router.navigate(['/', 'editor', 'production-countries', 'new']);
  }
}
