import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';

@Component({
  selector: 'editor-production-companies-list',
  templateUrl: './production-companies-list.component.html',
  styleUrls: ['./production-companies-list.component.scss'],
})
export class ProductionCompaniesListComponent implements OnInit {
  constructor(private store: Store<AppState>, private router: Router) {}

  ngOnInit(): void {}

  onNewProductionCompany() {
    this.router.navigate(['/', 'editor', 'production-companies', 'new']);
  }
}
