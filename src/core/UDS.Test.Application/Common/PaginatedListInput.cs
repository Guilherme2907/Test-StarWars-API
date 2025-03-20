namespace UDS.Test.Application.Common;

public record PaginatedListInput
{
    public int PerPage { get; set; } = 10;

    public int Page { get; set; } = 1;

    public string SearchBy { get; set; } = string.Empty;

    public string Search { get; set; } = string.Empty;

    public PaginatedListInput(int? perPage, int? page, string? search, string searchBy)
    {
        PerPage = perPage ?? PerPage;
        Page = page ?? Page;
        Search = search ?? Search;
        SearchBy = searchBy ?? SearchBy;
    }
}

