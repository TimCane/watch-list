import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { LanguageService } from 'api-client';
import { MessageService } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { catchError, debounceTime, from, map, of, switchMap } from 'rxjs';
import {
  createLanguage,
  createLanguageFailure,
  createLanguageSuccess,
  deleteLanguage,
  deleteLanguageFailure,
  deleteLanguageSuccess,
  loadLanguageFailure,
  loadLanguageSuccess,
  loadLanguages,
  loadLanguagesFailure,
  loadLanguagesSuccess,
  selectLanguage,
  updateLanguage,
  updateLanguageFailure,
  updateLanguageSuccess,
} from './languages.action';
import { getLanguages } from './languages.selectors';

@Injectable()
export class LanguagesEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private languageService: LanguageService,
    private messageService: MessageService
  ) {}

  selectLanguage$ = createEffect(() =>
    this.actions$.pipe(
      ofType(selectLanguage),
      concatLatestFrom((action) => this.store.select(getLanguages)),
      switchMap(([{ languageId }, languages]) => {
        var m = languages.find((m) => m.id == languageId);
        if (m) {
          return of(loadLanguageSuccess({ language: m }));
        }
        return from(this.languageService.getLanguage(languageId!)).pipe(
          map((language) => loadLanguageSuccess({ language })),
          catchError((error) => of(loadLanguageFailure({ error })))
        );
      })
    )
  );

  loadLanguages$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadLanguages),
      switchMap(({ request }) => {
        return from(this.languageService.getLanguages(request)).pipe(
          map(({ languages, total }) =>
            loadLanguagesSuccess({
              languages: languages ?? [],
              total: total ?? 0,
            })
          ),
          catchError((error) => of(loadLanguagesFailure({ error })))
        );
      })
    )
  );

  createLanguage$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createLanguage),
      switchMap(({ language }) =>
        from(this.languageService.createLanguage(language)).pipe(
          map((newLanguage) =>
            createLanguageSuccess({ language: newLanguage })
          ),
          catchError((error) => of(createLanguageFailure({ error })))
        )
      )
    )
  );

  deleteLanguage$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteLanguage),
      switchMap(({ language }) =>
        from(this.languageService.deleteLanguage(language)).pipe(
          map((success) => {
            if (success) {
              return deleteLanguageSuccess({
                languageId: language.id!,
                success,
              });
            } else {
              return deleteLanguageFailure({
                error: 'Unable to delete language',
              });
            }
          }),
          catchError((error) => of(deleteLanguageFailure({ error })))
        )
      )
    )
  );

  updateLanguage$ = createEffect(() =>
    this.actions$.pipe(
      ofType(updateLanguage),
      switchMap(({ language }) =>
        from(this.languageService.updateLanguage(language)).pipe(
          map((newLanguage) =>
            updateLanguageSuccess({ language: newLanguage })
          ),
          catchError((error) => of(updateLanguageFailure({ error })))
        )
      )
    )
  );

  notifyUpdate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateLanguageSuccess),
        map(({ language }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Language Updated',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyCreate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createLanguageSuccess),
        map(({ language }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Language Created',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyDelete$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteLanguageSuccess),
        debounceTime(100),
        map(({ languageId }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Language Deleted',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );
}
