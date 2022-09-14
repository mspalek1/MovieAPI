using System.ComponentModel;

namespace Domain.Queries
{
    public class MovieQuery
    {
        public string SearchPhase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public ListSortDirection SortDirection { get; set; }
    }
}