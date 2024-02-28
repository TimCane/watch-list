import { PagedRequest } from 'api-client';
import { LazyLoadEvent } from 'primeng/api';

export function LazyLoadToPaginationRequest(
  event: LazyLoadEvent
): PagedRequest {
  return {
    take: event.rows ?? undefined,
    skip: event.first ?? undefined,
    search: event.globalFilter ?? undefined,
    sortField: event.sortField ?? undefined,
    sortOrder: event.sortOrder ?? undefined,
  };
}
