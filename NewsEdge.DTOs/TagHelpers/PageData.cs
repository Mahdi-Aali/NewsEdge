namespace NewsEdge.Utilities.TagHelpers;

public class PageData
{
    public int TotalItems { get; set; }
    public int ItemPerPage { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages
    { get
        {
            return (int)Math.Ceiling((double)TotalItems / ItemPerPage);
        }
    }
}
