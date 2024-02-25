import { CollectionsState } from './modules/editor/state/collections/collections.state';
import { CreditsState } from './modules/editor/state/credits/credits.state';
import { GenresState } from './modules/editor/state/genres/genres.state';
import { KeywordsState } from './modules/editor/state/keywords/keywords.state';
import { LanguagesState } from './modules/editor/state/languages/languages.state';
import { MoviesState } from './modules/editor/state/movies/movies.state';
import { ProductionCompaniesState } from './modules/editor/state/production-companies/production-companies.state';
import { ProductionCountriesState } from './modules/editor/state/production-countries/production-countries.state';
import { AuthenticationState } from './modules/shared/state/authentication.state';

export interface AppState {
  authentication: AuthenticationState;
  collections: CollectionsState;
  credits: CreditsState;
  genres: GenresState;
  keywords: KeywordsState;
  languages: LanguagesState;
  movies: MoviesState;
  productionCompanies: ProductionCompaniesState;
  productionCountries: ProductionCountriesState;
}
