namespace WatchList.Seed.Models
{
    internal class CsvMovie
    {
        public bool? adult { get; set; } //False,
        public CollectionItem? belongs_to_collection { get; set; }
        public int? budget { get; set; } //30000000
        public List<GenreItem>? genres { get; set; } 
        public string? homepage { get; set; } //http://toystory.disney.com/toy-story,
        public int id { get; set; }
        public string? imdb_id { get; set; }
        public string? original_language { get; set; }
        public string? original_title { get; set; }
        public string? overview { get; set; } 
        public string? popularity { get; set; }
        public string? poster_path { get; set; }
        public List<ProductionCompanyItem>? production_companies { get; set; }
        public List<ProductionCountryItem>? production_countries { get; set; } 
        public DateTime? release_date { get; set; }
        public long? revenue { get; set; }
        public decimal? runtime { get; set; }
        public List<LanguageItem>? spoken_languages { get; set; } 
        public string? status { get; set; }
        public string? tagline { get; set; } 
        public string? title { get; set; }
        public string? video { get; set; }
        public string? vote_average { get; set; }
        public string? vote_count { get; set; }
    }

    public class CollectionItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
    }

    public class GenreItem
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ProductionCompanyItem
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ProductionCountryItem
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class LanguageItem
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }
}