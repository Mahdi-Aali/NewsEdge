using NewsEdge.Utilities.TagHelpers;

namespace NewsEdge.Utilities.PaginationModels;

public class ItemsWithPageDataViewModel<T> where T : class
{
    public PageData PageData { get; set; } = new();

    public IEnumerable<T> Entities { get; set; } = Enumerable.Empty<T>();
}
