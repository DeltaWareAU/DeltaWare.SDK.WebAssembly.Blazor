using DeltaWare.SDK.Data.Paging;

// ReSharper disable once CheckNamespace
namespace MudBlazor
{
    public static class MudTableExtensions
    {
        public static IPagedQuery ToPagedQuery(this TableState state, string searchString)
        {
            return new PagedQuery
            {
                PageIndex = state.Page,
                PageItems = state.PageSize,
                SortDescending = state.SortDirection == SortDirection.Descending,
                SearchString = searchString,
                SortString = state.SortLabel
            };
        }

        public static TableData<TItem> ToTableData<TItem>(this IPagedResult<TItem> pagedResult)
        {
            return new TableData<TItem>
            {
                TotalItems = pagedResult.FilteredRecords,
                Items = pagedResult.Data
            };
        }
    }
}