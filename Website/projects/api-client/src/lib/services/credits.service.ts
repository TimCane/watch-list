import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api-client.service';
import { DataService } from '../data-service';
import {
  CreateCreditResponse,
  Credit,
  CreditResponse,
  CreditsResponse,
  DeleteCreditResponse,
  SortOrderEnum,
  UpdateCreditResponse,
} from '../generated-api-client.service';
import { PagedRequest } from '../models/paged-request.interface';
import { DataDictionary } from './data-dictionary';

@Injectable({
  providedIn: 'root',
})
export class CreditService extends DataService {
  private creditsCache = new DataDictionary<Observable<CreditsResponse>>();

  constructor(private apiService: ApiClientService) {
    super();
  }

  getCredits(filter: PagedRequest): Observable<CreditsResponse> {
    let sortOrder =
      filter.sortOrder == -1 ? SortOrderEnum.Asc : SortOrderEnum.Desc;

    const cacheArgs = [
      filter.skip + '',
      filter.take + '',
      filter.search + '',
      filter.sortField + '',
      sortOrder + '',
    ];

    return this.creditsCache.loadFromCache(cacheArgs, () => {
      return this.mapResult(
        this.apiService.creditsAll(
          filter.skip,
          filter.take,
          filter.search,
          filter.sortField,
          sortOrder
        ),
        (res: CreditsResponse) => res,
        () => {},
        (err) => this.handleError('getCredits', err)
      );
    });
  }

  getCredit(id: string): Observable<Credit> {
    return this.mapResult(
      this.apiService.creditsGET(id),
      (res: CreditResponse) => res.credit as Credit,
      () => {},
      (err) => this.handleError('getCredit', err)
    );
  }

  createCredit(credit: Credit): Observable<Credit> {
    return this.mapResult(
      this.apiService.creditsPOST({
        ...credit,
      }),
      (res: CreateCreditResponse) => res.credit as Credit,
      () => {},
      (err) => this.handleError('createCredit', err)
    );
  }

  updateCredit(credit: Credit): Observable<Credit> {
    return this.mapResult(
      this.apiService.creditsPUT(credit.id!, {
        ...credit,
      }),
      (res: UpdateCreditResponse) => res.credit as Credit,
      () => {},
      (err) => this.handleError('updateCredit', err)
    );
  }

  deleteCredit(credit: Credit): Observable<boolean> {
    return this.mapResult(
      this.apiService.creditsDELETE(credit.id!),
      (res: DeleteCreditResponse) => res.success as boolean,
      () => {},
      (err) => this.handleError('deleteCredit', err)
    );
  }
}
