using UDS.Test.Application.Common;

namespace UDS.Test.Api.Models.Response;

public record ApiResponseList<T> : ApiResponse<IReadOnlyList<T>>
{
    public ApiResponseListMeta Meta { get; }

    public ApiResponseList(int currentPage, int perPage, int total, IReadOnlyList<T> data)
        : base(data)
    {
        Meta = new
        (
            currentPage,
            perPage,
            total
        );
    }

    public ApiResponseList(PaginatedListInputOutput<T> output)
       : base(output.Items)
    {
        Meta = new
        (
            output.CurrentPage,
            output.PerPage,
            output.Total
        );
    }
}
