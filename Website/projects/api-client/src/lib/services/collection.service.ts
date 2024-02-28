import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api-client.service';
import { DataService } from '../data-service';
import {
  Collection,
  CollectionResponse,
  CollectionsResponse,
  CreateCollectionResponse,
  DeleteCollectionResponse,
  SortOrderEnum,
  UpdateCollectionResponse,
} from '../generated-api-client.service';
import { PagedRequest } from '../models/paged-request.interface';
import { DataDictionary } from './data-dictionary';

@Injectable({
  providedIn: 'root',
})
export class CollectionService extends DataService {
  private collectionsCache = new DataDictionary<
    Observable<CollectionsResponse>
  >();

  constructor(private apiService: ApiClientService) {
    super();
  }

  getCollections(filter: PagedRequest): Observable<CollectionsResponse> {
    let sortOrder =
      filter.sortOrder == -1 ? SortOrderEnum.Asc : SortOrderEnum.Desc;

    const cacheArgs = [
      filter.skip + '',
      filter.take + '',
      filter.search + '',
      filter.sortField + '',
      sortOrder + '',
    ];

    return this.collectionsCache.loadFromCache(cacheArgs, () => {
      return this.mapResult(
        this.apiService.collectionsAll(
          filter.skip,
          filter.take,
          filter.search,
          filter.sortField,
          sortOrder
        ),
        (res: CollectionsResponse) => res,
        () => {},
        (err) => this.handleError('getCollections', err)
      );
    });
  }

  getCollection(id: string): Observable<Collection> {
    return this.mapResult(
      this.apiService.collectionsGET(id),
      (res: CollectionResponse) => res.collection as Collection,
      () => {},
      (err) => this.handleError('getCollection', err)
    );
  }

  createCollection(collection: Collection): Observable<Collection> {
    return this.mapResult(
      this.apiService.collectionsPOST({
        ...collection,
      }),
      (res: CreateCollectionResponse) => res.collection as Collection,
      () => {},
      (err) => this.handleError('createCollection', err)
    );
  }

  updateCollection(collection: Collection): Observable<Collection> {
    return this.mapResult(
      this.apiService.collectionsPUT(collection.id!, {
        ...collection,
      }),
      (res: UpdateCollectionResponse) => res.collection as Collection,
      () => {},
      (err) => this.handleError('updateCollection', err)
    );
  }

  deleteCollection(collection: Collection): Observable<boolean> {
    return this.mapResult(
      this.apiService.collectionsDELETE(collection.id!),
      (res: DeleteCollectionResponse) => res.success as boolean,
      () => {},
      (err) => this.handleError('deleteCollection', err)
    );
  }
}
