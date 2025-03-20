namespace UDS.Test.Application.Common;

public record PaginatedListInputOutput<T>
{
    public int CurrentPage { get; set; } 

    public int PerPage { get; set; }

    public int Total {  get; set; }

    public IReadOnlyList<T> Items { get; set; }

    public PaginatedListInputOutput(int currentPage, int perPage, int total, IReadOnlyList<T> items)
    {
        CurrentPage = currentPage;
        PerPage = perPage;
        Total = total;
        Items = items;
    }
}

