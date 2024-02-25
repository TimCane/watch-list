import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { ProductionCountryService } from 'api-client';
import { MessageService } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { catchError, debounceTime, from, map, of, switchMap } from 'rxjs';
import {
  createProductionCountry,
  createProductionCountryFailure,
  createProductionCountrySuccess,
  deleteProductionCountry,
  deleteProductionCountryFailure,
  deleteProductionCountrySuccess,
  loadProductionCountries,
  loadProductionCountriesFailure,
  loadProductionCountriesSuccess,
  loadProductionCountryFailure,
  loadProductionCountrySuccess,
  selectProductionCountry,
  updateProductionCountry,
  updateProductionCountryFailure,
  updateProductionCountrySuccess,
} from './production-countries.action';
import { getProductionCountries } from './production-countries.selectors';

@Injectable()
export class ProductionCountriesEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private productionCountryService: ProductionCountryService,
    private messageService: MessageService
  ) {}

  selectProductionCountry$ = createEffect(() =>
    this.actions$.pipe(
      ofType(selectProductionCountry),
      concatLatestFrom((action) => this.store.select(getProductionCountries)),
      switchMap(([{ productionCountryId }, productionCountries]) => {
        var m = productionCountries.find((m) => m.id == productionCountryId);
        if (m) {
          return of(loadProductionCountrySuccess({ productionCountry: m }));
        }
        return from(
          this.productionCountryService.getProductionCountry(
            productionCountryId!
          )
        ).pipe(
          map((productionCountry) =>
            loadProductionCountrySuccess({ productionCountry })
          ),
          catchError((error) => of(loadProductionCountryFailure({ error })))
        );
      })
    )
  );

  loadProductionCountries$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadProductionCountries),
      switchMap(({ request }) => {
        return from(
          this.productionCountryService.getProductionCountries(request)
        ).pipe(
          map(({ productionCountries, total }) =>
            loadProductionCountriesSuccess({
              productionCountries: productionCountries ?? [],
              total: total ?? 0,
            })
          ),
          catchError((error) => of(loadProductionCountriesFailure({ error })))
        );
      })
    )
  );

  createProductionCountry$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createProductionCountry),
      switchMap(({ productionCountry }) =>
        from(
          this.productionCountryService.createProductionCountry(
            productionCountry
          )
        ).pipe(
          map((newProductionCountry) =>
            createProductionCountrySuccess({
              productionCountry: newProductionCountry,
            })
          ),
          catchError((error) => of(createProductionCountryFailure({ error })))
        )
      )
    )
  );

  deleteProductionCountry$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteProductionCountry),
      switchMap(({ productionCountry }) =>
        from(
          this.productionCountryService.deleteProductionCountry(
            productionCountry
          )
        ).pipe(
          map((success) => {
            if (success) {
              return deleteProductionCountrySuccess({
                productionCountryId: productionCountry.id!,
                success,
              });
            } else {
              return deleteProductionCountryFailure({
                error: 'Unable to delete productionCountry',
              });
            }
          }),
          catchError((error) => of(deleteProductionCountryFailure({ error })))
        )
      )
    )
  );

  updateProductionCountry$ = createEffect(() =>
    this.actions$.pipe(
      ofType(updateProductionCountry),
      switchMap(({ productionCountry }) =>
        from(
          this.productionCountryService.updateProductionCountry(
            productionCountry
          )
        ).pipe(
          map((newProductionCountry) =>
            updateProductionCountrySuccess({
              productionCountry: newProductionCountry,
            })
          ),
          catchError((error) => of(updateProductionCountryFailure({ error })))
        )
      )
    )
  );

  notifyUpdate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateProductionCountrySuccess),
        map(({ productionCountry }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'ProductionCountry Updated',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyCreate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createProductionCountrySuccess),
        map(({ productionCountry }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'ProductionCountry Created',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyDelete$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteProductionCountrySuccess),
        debounceTime(100),
        map(({ productionCountryId }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'ProductionCountry Deleted',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );
}
