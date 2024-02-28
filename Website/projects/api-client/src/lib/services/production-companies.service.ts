import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api-client.service';
import { DataService } from '../data-service';
import {
  CreateProductionCompanyResponse,
  DeleteProductionCompanyResponse,
  ProductionCompaniesResponse,
  ProductionCompany,
  ProductionCompanyResponse,
  SortOrderEnum,
  UpdateProductionCompanyResponse,
} from '../generated-api-client.service';
import { PagedRequest } from '../models/paged-request.interface';
import { DataDictionary } from './data-dictionary';

@Injectable({
  providedIn: 'root',
})
export class ProductionCompanyService extends DataService {
  private productionCompaniesCache = new DataDictionary<
    Observable<ProductionCompaniesResponse>
  >();

  constructor(private apiService: ApiClientService) {
    super();
  }

  getProductionCompanies(
    filter: PagedRequest
  ): Observable<ProductionCompaniesResponse> {
    let sortOrder =
      filter.sortOrder == -1 ? SortOrderEnum.Asc : SortOrderEnum.Desc;

    const cacheArgs = [
      filter.skip + '',
      filter.take + '',
      filter.search + '',
      filter.sortField + '',
      sortOrder + '',
    ];

    return this.productionCompaniesCache.loadFromCache(cacheArgs, () => {
      return this.mapResult(
        this.apiService.productionCompaniesAll(
          filter.skip,
          filter.take,
          filter.search,
          filter.sortField,
          sortOrder
        ),
        (res: ProductionCompaniesResponse) => res,
        () => {},
        (err) => this.handleError('getProductionCompanies', err)
      );
    });
  }

  getProductionCompany(id: string): Observable<ProductionCompany> {
    return this.mapResult(
      this.apiService.productionCompaniesGET(id),
      (res: ProductionCompanyResponse) =>
        res.productionCompany as ProductionCompany,
      () => {},
      (err) => this.handleError('getProductionCompany', err)
    );
  }

  createProductionCompany(
    productionCompany: ProductionCompany
  ): Observable<ProductionCompany> {
    return this.mapResult(
      this.apiService.productionCompaniesPOST({
        ...productionCompany,
      }),
      (res: CreateProductionCompanyResponse) =>
        res.productionCompany as ProductionCompany,
      () => {},
      (err) => this.handleError('createProductionCompany', err)
    );
  }

  updateProductionCompany(
    productionCompany: ProductionCompany
  ): Observable<ProductionCompany> {
    return this.mapResult(
      this.apiService.productionCompaniesPUT(productionCompany.id!, {
        ...productionCompany,
      }),
      (res: UpdateProductionCompanyResponse) =>
        res.productionCompany as ProductionCompany,
      () => {},
      (err) => this.handleError('updateProductionCompany', err)
    );
  }

  deleteProductionCompany(
    productionCompany: ProductionCompany
  ): Observable<boolean> {
    return this.mapResult(
      this.apiService.productionCompaniesDELETE(productionCompany.id!),
      (res: DeleteProductionCompanyResponse) => res.success as boolean,
      () => {},
      (err) => this.handleError('deleteProductionCompany', err)
    );
  }
}
