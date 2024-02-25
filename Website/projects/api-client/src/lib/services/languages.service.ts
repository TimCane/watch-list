import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api-client.service';
import { DataService } from '../data-service';
import {
  CreateLanguageResponse,
  DeleteLanguageResponse,
  Language,
  LanguageResponse,
  LanguagesResponse,
  SortOrderEnum,
  UpdateLanguageResponse,
} from '../generated-api-client.service';
import { PagedRequest } from '../models/paged-request.interface';
import { DataDictionary } from './data-dictionary';

@Injectable({
  providedIn: 'root',
})
export class LanguageService extends DataService {
  private languagesCache = new DataDictionary<Observable<LanguagesResponse>>();

  constructor(private apiService: ApiClientService) {
    super();
  }

  getLanguages(filter: PagedRequest): Observable<LanguagesResponse> {
    let sortOrder =
      filter.sortOrder == -1 ? SortOrderEnum.Asc : SortOrderEnum.Desc;

    const cacheArgs = [
      filter.skip + '',
      filter.take + '',
      filter.search + '',
      filter.sortField + '',
      sortOrder + '',
    ];

    return this.languagesCache.loadFromCache(cacheArgs, () => {
      return this.mapResult(
        this.apiService.languagesAll(
          filter.skip,
          filter.take,
          filter.search,
          filter.sortField,
          sortOrder
        ),
        (res: LanguagesResponse) => res,
        () => {},
        (err) => this.handleError('getLanguages', err)
      );
    });
  }

  getLanguage(id: string): Observable<Language> {
    return this.mapResult(
      this.apiService.languagesGET(id),
      (res: LanguageResponse) => res.language as Language,
      () => {},
      (err) => this.handleError('getLanguage', err)
    );
  }

  createLanguage(language: Language): Observable<Language> {
    return this.mapResult(
      this.apiService.languagesPOST({
        ...language,
      }),
      (res: CreateLanguageResponse) => res.language as Language,
      () => {},
      (err) => this.handleError('createLanguage', err)
    );
  }

  updateLanguage(language: Language): Observable<Language> {
    return this.mapResult(
      this.apiService.languagesPUT(language.id!, {
        ...language,
      }),
      (res: UpdateLanguageResponse) => res.language as Language,
      () => {},
      (err) => this.handleError('updateLanguage', err)
    );
  }

  deleteLanguage(language: Language): Observable<boolean> {
    return this.mapResult(
      this.apiService.languagesDELETE(language.id!),
      (res: DeleteLanguageResponse) => res.success as boolean,
      () => {},
      (err) => this.handleError('deleteLanguage', err)
    );
  }
}
