import { createReducer, on } from '@ngrx/store';
import {
  createCollection,
  createCollectionFailure,
  createCollectionSuccess,
  deleteCollection,
  deleteCollectionFailure,
  deleteCollectionSuccess,
  loadCollectionFailure,
  loadCollectionSuccess,
  loadCollections,
  loadCollectionsFailure,
  loadCollectionsSuccess,
  selectCollection,
  updateCollection,
  updateCollectionFailure,
  updateCollectionSuccess,
} from './collections.action';
import {
  CollectionsState,
  collectionsAdapter,
  initialState,
} from './collections.state';

export const collectionsReducer = createReducer<CollectionsState>(
  initialState,

  on(selectCollection, (state, { collectionId }) => {
    return { ...state, selectedCollectionId: collectionId };
  }),

  on(loadCollections, (state) => ({
    ...state,
    total: 0,
    status: 'loading',
    selectedCollectionId: null,
  })),

  on(loadCollectionSuccess, (state, { collection }) => {
    return collectionsAdapter.upsertOne(collection, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(loadCollectionFailure, (state, { error }) => {
    return collectionsAdapter.removeAll({
      ...state,
      total: 0,
      selectedCollectionId: null,
      error: error,
      status: 'error',
    });
  }),

  on(loadCollectionsSuccess, (state, { collections, total }) => {
    return collectionsAdapter.setAll(collections, {
      ...state,
      total,
      error: null,
      status: 'success',
    });
  }),

  on(loadCollectionsFailure, (state, { error }) => {
    return collectionsAdapter.removeAll({
      ...state,
      total: 0,
      selectedCollectionId: null,
      error: error,
      status: 'error',
    });
  }),

  on(updateCollection, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(updateCollectionSuccess, (state, { collection }) => {
    return collectionsAdapter.updateOne(
      { id: collection.id!, changes: collection },
      {
        ...state,
        error: null,
        status: 'success',
      }
    );
  }),

  on(updateCollectionFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(createCollection, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(createCollectionSuccess, (state, { collection }) => {
    return collectionsAdapter.addOne(collection, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(createCollectionFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(deleteCollection, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(deleteCollectionSuccess, (state, { collectionId }) => {
    return collectionsAdapter.removeOne(collectionId, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(deleteCollectionFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  }))
);

export const getSelectedCollectionId = (state: CollectionsState) =>
  state.selectedCollectionId;

// get the selectors
const { selectIds, selectEntities, selectAll, selectTotal } =
  collectionsAdapter.getSelectors();

// select the array of collection ids
export const selectCollectionIds = selectIds;

// select the dictionary of collection entities
export const selectCollectionEntities = selectEntities;

// select the array of collections
export const selectAllCollections = selectAll;

// select the total collection count
export const selectCollectionTotal = selectTotal;
