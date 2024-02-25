import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api-client.service';
import { DataService } from '../data-service';
import {
  CreateGenreResponse,
  DeleteGenreResponse,
  Genre,
  GenreResponse,
  GenresResponse,
  SortOrderEnum,
  UpdateGenreResponse,
} from '../generated-api-client.service';
import { PagedRequest } from '../models/paged-request.interface';
import { DataDictionary } from './data-dictionary';

@Injectable({
  providedIn: 'root',
})
export class GenreService extends DataService {
  private genresCache = new DataDictionary<Observable<GenresResponse>>();

  constructor(private apiService: ApiClientService) {
    super();
  }

  getGenres(filter: PagedRequest): Observable<GenresResponse> {
    let sortOrder =
      filter.sortOrder == -1 ? SortOrderEnum.Asc : SortOrderEnum.Desc;

    const cacheArgs = [
      filter.skip + '',
      filter.take + '',
      filter.search + '',
      filter.sortField + '',
      sortOrder + '',
    ];

    return this.genresCache.loadFromCache(cacheArgs, () => {
      return this.mapResult(
        this.apiService.genresAll(
          filter.skip,
          filter.take,
          filter.search,
          filter.sortField,
          sortOrder
        ),
        (res: GenresResponse) => res,
        () => {},
        (err) => this.handleError('getGenres', err)
      );
    });
  }

  getGenre(id: string): Observable<Genre> {
    return this.mapResult(
      this.apiService.genresGET(id),
      (res: GenreResponse) => res.genre as Genre,
      () => {},
      (err) => this.handleError('getGenre', err)
    );
  }

  createGenre(genre: Genre): Observable<Genre> {
    return this.mapResult(
      this.apiService.genresPOST({
        ...genre,
      }),
      (res: CreateGenreResponse) => res.genre as Genre,
      () => {},
      (err) => this.handleError('createGenre', err)
    );
  }

  updateGenre(genre: Genre): Observable<Genre> {
    return this.mapResult(
      this.apiService.genresPUT(genre.id!, {
        ...genre,
      }),
      (res: UpdateGenreResponse) => res.genre as Genre,
      () => {},
      (err) => this.handleError('updateGenre', err)
    );
  }

  deleteGenre(genre: Genre): Observable<boolean> {
    return this.mapResult(
      this.apiService.genresDELETE(genre.id!),
      (res: DeleteGenreResponse) => res.success as boolean,
      () => {},
      (err) => this.handleError('deleteGenre', err)
    );
  }
}
