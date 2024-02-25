import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { ProductionCompanyService } from 'api-client';
import { MessageService } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { catchError, debounceTime, from, map, of, switchMap } from 'rxjs';
import {
  createProductionCompany,
  createProductionCompanyFailure,
  createProductionCompanySuccess,
  deleteProductionCompany,
  deleteProductionCompanyFailure,
  deleteProductionCompanySuccess,
  loadProductionCompanies,
  loadProductionCompaniesFailure,
  loadProductionCompaniesSuccess,
  loadProductionCompanyFailure,
  loadProductionCompanySuccess,
  selectProductionCompany,
  updateProductionCompany,
  updateProductionCompanyFailure,
  updateProductionCompanySuccess,
} from './production-companies.action';
import { getProductionCompanies } from './production-companies.selectors';

@Injectable()
export class ProductionCompaniesEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private productionCompanyService: ProductionCompanyService,
    private messageService: MessageService
  ) {}

  selectProductionCompany$ = createEffect(() =>
    this.actions$.pipe(
      ofType(selectProductionCompany),
      concatLatestFrom((action) => this.store.select(getProductionCompanies)),
      switchMap(([{ productionCompanyId }, productionCompanies]) => {
        var m = productionCompanies.find((m) => m.id == productionCompanyId);
        if (m) {
          return of(loadProductionCompanySuccess({ productionCompany: m }));
        }
        return from(
          this.productionCompanyService.getProductionCompany(
            productionCompanyId!
          )
        ).pipe(
          map((productionCompany) =>
            loadProductionCompanySuccess({ productionCompany })
          ),
          catchError((error) => of(loadProductionCompanyFailure({ error })))
        );
      })
    )
  );

  loadProductionCompanies$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadProductionCompanies),
      switchMap(({ request }) => {
        return from(
          this.productionCompanyService.getProductionCompanies(request)
        ).pipe(
          map(({ productionCompanies, total }) =>
            loadProductionCompaniesSuccess({
              productionCompanies: productionCompanies ?? [],
              total: total ?? 0,
            })
          ),
          catchError((error) => of(loadProductionCompaniesFailure({ error })))
        );
      })
    )
  );

  createProductionCompany$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createProductionCompany),
      switchMap(({ productionCompany }) =>
        from(
          this.productionCompanyService.createProductionCompany(
            productionCompany
          )
        ).pipe(
          map((newProductionCompany) =>
            createProductionCompanySuccess({
              productionCompany: newProductionCompany,
            })
          ),
          catchError((error) => of(createProductionCompanyFailure({ error })))
        )
      )
    )
  );

  deleteProductionCompany$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteProductionCompany),
      switchMap(({ productionCompany }) =>
        from(
          this.productionCompanyService.deleteProductionCompany(
            productionCompany
          )
        ).pipe(
          map((success) => {
            if (success) {
              return deleteProductionCompanySuccess({
                productionCompanyId: productionCompany.id!,
                success,
              });
            } else {
              return deleteProductionCompanyFailure({
                error: 'Unable to delete productionCompany',
              });
            }
          }),
          catchError((error) => of(deleteProductionCompanyFailure({ error })))
        )
      )
    )
  );

  updateProductionCompany$ = createEffect(() =>
    this.actions$.pipe(
      ofType(updateProductionCompany),
      switchMap(({ productionCompany }) =>
        from(
          this.productionCompanyService.updateProductionCompany(
            productionCompany
          )
        ).pipe(
          map((newProductionCompany) =>
            updateProductionCompanySuccess({
              productionCompany: newProductionCompany,
            })
          ),
          catchError((error) => of(updateProductionCompanyFailure({ error })))
        )
      )
    )
  );

  notifyUpdate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateProductionCompanySuccess),
        map(({ productionCompany }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'ProductionCompany Updated',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyCreate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createProductionCompanySuccess),
        map(({ productionCompany }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'ProductionCompany Created',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyDelete$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteProductionCompanySuccess),
        debounceTime(100),
        map(({ productionCompanyId }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'ProductionCompany Deleted',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );
}
