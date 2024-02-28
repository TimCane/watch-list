import { createAction, props } from '@ngrx/store';
import { Collection, PagedRequest } from 'api-client';

export const selectCollection = createAction(
  '[Collection Page] Select Collection',
  props<{ collectionId: string | null }>()
);

export const loadCollectionSuccess = createAction(
  '[Collection Page] Load Collection',
  props<{ collection: Collection }>()
);

export const loadCollectionFailure = createAction(
  '[Collection API] Collection Load Failure',
  props<{ error: string }>()
);

export const loadCollections = createAction(
  '[Collection Page] Load Collections',
  props<{ request: PagedRequest }>()
);

export const loadCollectionsSuccess = createAction(
  '[Collection API] Collections Load Success',
  props<{ collections: Collection[]; total: number }>()
);

export const loadCollectionsFailure = createAction(
  '[Collection API] Collections Load Failure',
  props<{ error: string }>()
);

export const updateCollection = createAction(
  '[Collection Page] Update Collection',
  props<{ collection: Collection }>()
);

export const updateCollectionSuccess = createAction(
  '[Collection API] Collection Update Success',
  props<{ collection: Collection }>()
);

export const updateCollectionFailure = createAction(
  '[Collection API] Collection Update Failure',
  props<{ error: string }>()
);

export const createCollection = createAction(
  '[Collection Page] Create Collection',
  props<{ collection: Collection }>()
);

export const createCollectionSuccess = createAction(
  '[Collection API] Collection Create Success',
  props<{ collection: Collection }>()
);

export const createCollectionFailure = createAction(
  '[Collection API] Collection Create Failure',
  props<{ error: string }>()
);

export const deleteCollection = createAction(
  '[Collection Page] Delete Collection',
  props<{ collection: Collection }>()
);

export const deleteCollectionSuccess = createAction(
  '[Collection API] Collection Delete Success',
  props<{ collectionId: string; success: boolean }>()
);

export const deleteCollectionFailure = createAction(
  '[Collection API] Collection Delete Failure',
  props<{ error: string }>()
);
