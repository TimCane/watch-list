import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api-client.service';
import { DataService } from '../data-service';
import {
  CreateKeywordResponse,
  DeleteKeywordResponse,
  Keyword,
  KeywordResponse,
  KeywordsResponse,
  SortOrderEnum,
  UpdateKeywordResponse,
} from '../generated-api-client.service';
import { PagedRequest } from '../models/paged-request.interface';
import { DataDictionary } from './data-dictionary';

@Injectable({
  providedIn: 'root',
})
export class KeywordService extends DataService {
  private keywordsCache = new DataDictionary<Observable<KeywordsResponse>>();

  constructor(private apiService: ApiClientService) {
    super();
  }

  getKeywords(filter: PagedRequest): Observable<KeywordsResponse> {
    let sortOrder =
      filter.sortOrder == -1 ? SortOrderEnum.Asc : SortOrderEnum.Desc;

    const cacheArgs = [
      filter.skip + '',
      filter.take + '',
      filter.search + '',
      filter.sortField + '',
      sortOrder + '',
    ];

    return this.keywordsCache.loadFromCache(cacheArgs, () => {
      return this.mapResult(
        this.apiService.keywordsAll(
          filter.skip,
          filter.take,
          filter.search,
          filter.sortField,
          sortOrder
        ),
        (res: KeywordsResponse) => res,
        () => {},
        (err) => this.handleError('getKeywords', err)
      );
    });
  }

  getKeyword(id: string): Observable<Keyword> {
    return this.mapResult(
      this.apiService.keywordsGET(id),
      (res: KeywordResponse) => res.keyword as Keyword,
      () => {},
      (err) => this.handleError('getKeyword', err)
    );
  }

  createKeyword(keyword: Keyword): Observable<Keyword> {
    return this.mapResult(
      this.apiService.keywordsPOST({
        ...keyword,
      }),
      (res: CreateKeywordResponse) => res.keyword as Keyword,
      () => {},
      (err) => this.handleError('createKeyword', err)
    );
  }

  updateKeyword(keyword: Keyword): Observable<Keyword> {
    return this.mapResult(
      this.apiService.keywordsPUT(keyword.id!, {
        ...keyword,
      }),
      (res: UpdateKeywordResponse) => res.keyword as Keyword,
      () => {},
      (err) => this.handleError('updateKeyword', err)
    );
  }

  deleteKeyword(keyword: Keyword): Observable<boolean> {
    return this.mapResult(
      this.apiService.keywordsDELETE(keyword.id!),
      (res: DeleteKeywordResponse) => res.success as boolean,
      () => {},
      (err) => this.handleError('deleteKeyword', err)
    );
  }
}
