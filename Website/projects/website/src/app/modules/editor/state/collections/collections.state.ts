import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Collection } from 'api-client';

export interface CollectionsState extends EntityState<Collection> {
  selectedCollectionId: string | null;
  total: number | null;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success'; //TODO: Enum
}

export function selectCollectionId(collection: Collection): string {
  return collection.id ?? '';
}

export const collectionsAdapter = createEntityAdapter<Collection>({
  selectId: selectCollectionId,
});

export const initialState: CollectionsState =
  collectionsAdapter.getInitialState({
    selectedCollectionId: null,
    total: 0,
    error: null,
    status: 'pending',
  });
