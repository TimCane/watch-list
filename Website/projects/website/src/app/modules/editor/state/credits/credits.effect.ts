import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { CreditService } from 'api-client';
import { MessageService } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { catchError, debounceTime, from, map, of, switchMap } from 'rxjs';
import {
  createCredit,
  createCreditFailure,
  createCreditSuccess,
  deleteCredit,
  deleteCreditFailure,
  deleteCreditSuccess,
  loadCreditFailure,
  loadCreditSuccess,
  loadCredits,
  loadCreditsFailure,
  loadCreditsSuccess,
  selectCredit,
  updateCredit,
  updateCreditFailure,
  updateCreditSuccess,
} from './credits.action';
import { getCredits } from './credits.selectors';

@Injectable()
export class CreditsEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private creditService: CreditService,
    private messageService: MessageService
  ) {}

  selectCredit$ = createEffect(() =>
    this.actions$.pipe(
      ofType(selectCredit),
      concatLatestFrom((action) => this.store.select(getCredits)),
      switchMap(([{ creditId }, credits]) => {
        var m = credits.find((m) => m.id == creditId);
        if (m) {
          return of(loadCreditSuccess({ credit: m }));
        }
        return from(this.creditService.getCredit(creditId!)).pipe(
          map((credit) => loadCreditSuccess({ credit })),
          catchError((error) => of(loadCreditFailure({ error })))
        );
      })
    )
  );

  loadCredits$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadCredits),
      switchMap(({ request }) => {
        return from(this.creditService.getCredits(request)).pipe(
          map(({ credits, total }) =>
            loadCreditsSuccess({
              credits: credits ?? [],
              total: total ?? 0,
            })
          ),
          catchError((error) => of(loadCreditsFailure({ error })))
        );
      })
    )
  );

  createCredit$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createCredit),
      switchMap(({ credit }) =>
        from(this.creditService.createCredit(credit)).pipe(
          map((newCredit) => createCreditSuccess({ credit: newCredit })),
          catchError((error) => of(createCreditFailure({ error })))
        )
      )
    )
  );

  deleteCredit$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteCredit),
      switchMap(({ credit }) =>
        from(this.creditService.deleteCredit(credit)).pipe(
          map((success) => {
            if (success) {
              return deleteCreditSuccess({
                creditId: credit.id!,
                success,
              });
            } else {
              return deleteCreditFailure({
                error: 'Unable to delete credit',
              });
            }
          }),
          catchError((error) => of(deleteCreditFailure({ error })))
        )
      )
    )
  );

  updateCredit$ = createEffect(() =>
    this.actions$.pipe(
      ofType(updateCredit),
      switchMap(({ credit }) =>
        from(this.creditService.updateCredit(credit)).pipe(
          map((newCredit) => updateCreditSuccess({ credit: newCredit })),
          catchError((error) => of(updateCreditFailure({ error })))
        )
      )
    )
  );

  notifyUpdate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateCreditSuccess),
        map(({ credit }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Credit Updated',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyCreate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createCreditSuccess),
        map(({ credit }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Credit Created',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyDelete$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteCreditSuccess),
        debounceTime(100),
        map(({ creditId }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Credit Deleted',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );
}
