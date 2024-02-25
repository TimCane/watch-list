import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api-client.service';
import { DataService } from '../data-service';
import {
  CreateProductionCountryResponse,
  DeleteProductionCountryResponse,
  ProductionCountriesResponse,
  ProductionCountry,
  ProductionCountryResponse,
  SortOrderEnum,
  UpdateProductionCountryResponse,
} from '../generated-api-client.service';
import { PagedRequest } from '../models/paged-request.interface';
import { DataDictionary } from './data-dictionary';

@Injectable({
  providedIn: 'root',
})
export class ProductionCountryService extends DataService {
  private productionCountriesCache = new DataDictionary<
    Observable<ProductionCountriesResponse>
  >();

  constructor(private apiService: ApiClientService) {
    super();
  }

  getProductionCountries(
    filter: PagedRequest
  ): Observable<ProductionCountriesResponse> {
    let sortOrder =
      filter.sortOrder == -1 ? SortOrderEnum.Asc : SortOrderEnum.Desc;

    const cacheArgs = [
      filter.skip + '',
      filter.take + '',
      filter.search + '',
      filter.sortField + '',
      sortOrder + '',
    ];

    return this.productionCountriesCache.loadFromCache(cacheArgs, () => {
      return this.mapResult(
        this.apiService.productionCountriesAll(
          filter.skip,
          filter.take,
          filter.search,
          filter.sortField,
          sortOrder
        ),
        (res: ProductionCountriesResponse) => res,
        () => {},
        (err) => this.handleError('getProductionCountries', err)
      );
    });
  }

  getProductionCountry(id: string): Observable<ProductionCountry> {
    return this.mapResult(
      this.apiService.productionCountriesGET(id),
      (res: ProductionCountryResponse) =>
        res.productionCountry as ProductionCountry,
      () => {},
      (err) => this.handleError('getProductionCountry', err)
    );
  }

  createProductionCountry(
    productionCountry: ProductionCountry
  ): Observable<ProductionCountry> {
    return this.mapResult(
      this.apiService.productionCountriesPOST({
        ...productionCountry,
      }),
      (res: CreateProductionCountryResponse) =>
        res.productionCountry as ProductionCountry,
      () => {},
      (err) => this.handleError('createProductionCountry', err)
    );
  }

  updateProductionCountry(
    productionCountry: ProductionCountry
  ): Observable<ProductionCountry> {
    return this.mapResult(
      this.apiService.productionCountriesPUT(productionCountry.id!, {
        ...productionCountry,
      }),
      (res: UpdateProductionCountryResponse) =>
        res.productionCountry as ProductionCountry,
      () => {},
      (err) => this.handleError('updateProductionCountry', err)
    );
  }

  deleteProductionCountry(
    productionCountry: ProductionCountry
  ): Observable<boolean> {
    return this.mapResult(
      this.apiService.productionCountriesDELETE(productionCountry.id!),
      (res: DeleteProductionCountryResponse) => res.success as boolean,
      () => {},
      (err) => this.handleError('deleteProductionCountry', err)
    );
  }
}
