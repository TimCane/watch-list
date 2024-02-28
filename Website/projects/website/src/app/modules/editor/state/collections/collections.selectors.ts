import { createFeatureSelector, createSelector } from '@ngrx/store';
import { CollectionsState, collectionsAdapter } from './collections.state';

export const collectionsFeature =
  createFeatureSelector<CollectionsState>('collectionsFeature');
const selector = <T>(mapping: (state: CollectionsState) => T) =>
  createSelector(collectionsFeature, mapping);

const { selectEntities, selectAll } = collectionsAdapter.getSelectors();

export const selectCollectionEntities = selector(selectEntities);

export const getCollections = selector(selectAll);

export const getSelectedCollectionId = selector(
  (state) => state.selectedCollectionId
);

export const getCollectionsTotal = selector((state) => state.total);

export const getCollection = createSelector(
  selectCollectionEntities,
  getSelectedCollectionId,
  (collections, selectedCollectionId) => {
    if (selectedCollectionId) {
      return collections[selectedCollectionId];
    }
    return null;
  }
);
