import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api-client.service';
import { DataService } from '../data-service';
import {
  CreateMovieResponse,
  DeleteMovieResponse,
  Movie,
  MovieResponse,
  MoviesResponse,
  SortOrderEnum,
  UpdateMovieResponse,
} from '../generated-api-client.service';
import { PagedRequest } from '../models/paged-request.interface';
import { DataDictionary } from './data-dictionary';

@Injectable({
  providedIn: 'root',
})
export class MovieService extends DataService {
  private moviesCache = new DataDictionary<Observable<MoviesResponse>>();

  constructor(private apiService: ApiClientService) {
    super();
  }

  getMovies(filter: PagedRequest): Observable<MoviesResponse> {
    let sortOrder =
      filter.sortOrder == -1 ? SortOrderEnum.Asc : SortOrderEnum.Desc;

    const cacheArgs = [
      filter.skip + '',
      filter.take + '',
      filter.search + '',
      filter.sortField + '',
      sortOrder + '',
    ];

    return this.moviesCache.loadFromCache(cacheArgs, () => {
      return this.mapResult(
        this.apiService.moviesAll(
          filter.skip,
          filter.take,
          filter.search,
          filter.sortField,
          sortOrder
        ),
        (res: MoviesResponse) => res,
        () => {},
        (err) => this.handleError('getMovies', err)
      );
    });
  }

  getMovie(id: string): Observable<Movie> {
    return this.mapResult(
      this.apiService.moviesGET(id),
      (res: MovieResponse) => res.movie as Movie,
      () => {},
      (err) => this.handleError('getMovie', err)
    );
  }

  createMovie(movie: Movie): Observable<Movie> {
    return this.mapResult(
      this.apiService.moviesPOST({
        ...movie,
      }),
      (res: CreateMovieResponse) => res.movie as Movie,
      () => {},
      (err) => this.handleError('createMovie', err)
    );
  }

  updateMovie(movie: Movie): Observable<Movie> {
    return this.mapResult(
      this.apiService.moviesPUT(movie.id!, {
        ...movie,
      }),
      (res: UpdateMovieResponse) => res.movie as Movie,
      () => {},
      (err) => this.handleError('updateMovie', err)
    );
  }

  deleteMovie(movie: Movie): Observable<boolean> {
    return this.mapResult(
      this.apiService.moviesDELETE(movie.id!),
      (res: DeleteMovieResponse) => res.success as boolean,
      () => {},
      (err) => this.handleError('deleteMovie', err)
    );
  }
}
