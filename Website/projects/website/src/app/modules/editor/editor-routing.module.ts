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
        children: [
          {
            path: ':id',
            loadChildren: () =>
              import('./features/movie-detail/movie-detail.module').then(
                (m) => m.MovieDetailModule
              ),
          },
          {
            path: '',
            loadChildren: () =>
              import('./features/movies-list/movies-list.module').then(
                (m) => m.MoviesListModule
              ),
          },
        ],
        data: {
          breadcrumb: 'Movies',
        },
      },
      {
        path: 'collections',
        children: [
          {
            path: ':id',
            loadChildren: () =>
              import(
                './features/collection-detail/collection-detail.module'
              ).then((m) => m.CollectionDetailModule),
          },
          {
            path: '',
            loadChildren: () =>
              import(
                './features/collections-list/collections-list.module'
              ).then((m) => m.CollectionsListModule),
          },
        ],
        data: {
          breadcrumb: 'Collections',
        },
      },
      {
        path: 'genres',
        children: [
          {
            path: ':id',
            loadChildren: () =>
              import('./features/genre-detail/genre-detail.module').then(
                (m) => m.GenreDetailModule
              ),
          },
          {
            path: '',
            loadChildren: () =>
              import('./features/genres-list/genres-list.module').then(
                (m) => m.GenresListModule
              ),
          },
        ],
        data: {
          breadcrumb: 'Genres',
        },
      },
      {
        path: 'credits',
        children: [
          {
            path: ':id',
            loadChildren: () =>
              import('./features/credit-detail/credit-detail.module').then(
                (m) => m.CreditDetailModule
              ),
          },
          {
            path: '',
            loadChildren: () =>
              import('./features/credits-list/credits-list.module').then(
                (m) => m.CreditsListModule
              ),
          },
        ],
        data: {
          breadcrumb: 'Credits',
        },
      },
      {
        path: 'keywords',
        children: [
          {
            path: ':id',
            loadChildren: () =>
              import('./features/keyword-detail/keyword-detail.module').then(
                (m) => m.KeywordDetailModule
              ),
          },
          {
            path: '',
            loadChildren: () =>
              import('./features/keywords-list/keywords-list.module').then(
                (m) => m.KeywordsListModule
              ),
          },
        ],
        data: {
          breadcrumb: 'Keywords',
        },
      },
      {
        path: 'languages',
        children: [
          {
            path: ':id',
            loadChildren: () =>
              import('./features/language-detail/language-detail.module').then(
                (m) => m.LanguageDetailModule
              ),
          },
          {
            path: '',
            loadChildren: () =>
              import('./features/languages-list/languages-list.module').then(
                (m) => m.LanguagesListModule
              ),
          },
        ],
        data: {
          breadcrumb: 'Languages',
        },
      },
      {
        path: 'production-companies',
        children: [
          {
            path: ':id',
            loadChildren: () =>
              import(
                './features/production-company-detail/production-company-detail.module'
              ).then((m) => m.ProductionCompanyDetailModule),
          },
          {
            path: '',
            loadChildren: () =>
              import(
                './features/production-companies-list/production-companies-list.module'
              ).then((m) => m.ProductionCompaniesListModule),
          },
        ],
        data: {
          breadcrumb: 'Production Companies',
        },
      },
      {
        path: 'production-countries',
        children: [
          {
            path: ':id',
            loadChildren: () =>
              import(
                './features/production-country-detail/production-country-detail.module'
              ).then((m) => m.ProductionCountryDetailModule),
          },
          {
            path: '',
            loadChildren: () =>
              import(
                './features/production-countries-list/production-countries-list.module'
              ).then((m) => m.ProductionCountriesListModule),
          },
        ],
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
