import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuardFunction } from '../shared/guards/auth.guard';
import { EditorComponent } from './editor.component';

const routes: Routes = [
  {
    path: '',
    component: EditorComponent,
    canActivate: [authGuardFunction],
    data: {
      breadcrumb: 'Editor',
    },
    children: [
      {
        path: 'dashboard',
        loadChildren: () =>
          import('./features/dashboard/dashboard.module').then(
            (m) => m.DashboardModule
          ),
        data: {
          breadcrumb: 'Dashboard',
        },
      },
      {
        path: 'movies',
        loadChildren: () =>
          import('./features/movies-list/movies-list.module').then(
            (m) => m.MoviesListModule
          ),
        data: {
          breadcrumb: 'Movies',
        },
      },
      {
        path: 'collections',
        loadChildren: () =>
          import('./features/collections-list/collections-list.module').then(
            (m) => m.CollectionsListModule
          ),
        data: {
          breadcrumb: 'Collections',
        },
      },
      {
        path: 'genres',
        loadChildren: () =>
          import('./features/genres-list/genres-list.module').then(
            (m) => m.GenresListModule
          ),
        data: {
          breadcrumb: 'Genres',
        },
      },
      {
        path: 'credits',
        loadChildren: () =>
          import('./features/credits-list/credits-list.module').then(
            (m) => m.CreditsListModule
          ),
        data: {
          breadcrumb: 'Credits',
        },
      },
      {
        path: 'keywords',
        loadChildren: () =>
          import('./features/keywords-list/keywords-list.module').then(
            (m) => m.KeywordsListModule
          ),
        data: {
          breadcrumb: 'Keywords',
        },
      },
      {
        path: 'languages',
        loadChildren: () =>
          import('./features/languages-list/languages-list.module').then(
            (m) => m.LanguagesListModule
          ),
        data: {
          breadcrumb: 'Languages',
        },
      },
      {
        path: 'production-companies',
        loadChildren: () =>
          import(
            './features/production-companies-list/production-companies-list.module'
          ).then((m) => m.ProductionCompaniesListModule),
        data: {
          breadcrumb: 'Production Companies',
        },
      },
      {
        path: 'production-countries',
        loadChildren: () =>
          import(
            './features/production-countries-list/production-countries-list.module'
          ).then((m) => m.ProductionCountriesListModule),
        data: {
          breadcrumb: 'Production Countries',
        },
      },
      {
        path: '',
        pathMatch: 'full',
        redirectTo: '/editor/dashboard',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EditorRoutingModule {}
