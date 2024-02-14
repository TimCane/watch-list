import { Observable, throwError } from 'rxjs';
import { catchError, map, shareReplay, tap } from 'rxjs/operators';
import { ApiException } from './generated-api-client.service';

const NOOP = () => {};

export class DataService {
  protected mapResult<T>(
    observable: Observable<any>,
    mapper: (data: any) => T,
    stateUpdater?: (res: T) => void,
    errorNotifier?: (err: any) => void
  ): Observable<T> {
    return observable.pipe(
      shareReplay(1),
      map(mapper),
      catchError((error: ApiException) => {
        if (errorNotifier) {
          errorNotifier(error);
        }
        return throwError(() => error);
      }),
      tap(stateUpdater || NOOP)
    );
  }

  handleError(operation: string, error: ApiException) {
    console.error(operation + ' ' + error.response);
  }
}
