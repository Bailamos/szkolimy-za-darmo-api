namespace Szkolimy_za_darmo_api.Controllers.Resources.Query
{
    public class UserQueryResource
    {
        public int? Localization {get; set;}
        public string Categories {get; set;}
        public string SortBy {get; set;}
        public bool IsSortAscending {get; set;}
        public int Page {get; set;}
        public int PageSize {get; set;}
    }
}