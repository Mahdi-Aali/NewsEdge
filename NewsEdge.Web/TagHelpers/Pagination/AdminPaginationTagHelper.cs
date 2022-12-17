using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NewsEdge.Utilities.TagHelpers;

namespace NewsEdge.Web.TagHelpers.Pagination
{
    [HtmlTargetElement("nav", Attributes = "page-data")]
    public class AdminPaginationTagHelper : TagHelper
    {
        [HtmlAttributeName("page-data")]
        public PageData PageData { get; set; } = new();

        [HtmlAttributeName("form-id")]
        public string FormId { get; set; } = string.Empty;


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (PageData.TotalItems > 1)
            {
                TagBuilder ul = new("ul");
                ul.AddCssClass("pagination justify-content-center");
                AddListItems(ref ul);
                output.Content.AppendHtml(ul);
            }
            else
            {
                output.SuppressOutput();
            }
        }

        private void AddListItems(ref TagBuilder parrentLit)
        {
            for (int index = 0; index < PageData.TotalPages; index++)
            {
                TagBuilder li = new("li");
                li.AddCssClass("page-item");
                if (index + 1 == PageData.CurrentPage)
                {
                    li.AddCssClass("active");
                }
                AddLink(ref li, (index + 1).ToString());
                parrentLit.InnerHtml.AppendHtml(li);
            }
        }

        private void AddLink(ref TagBuilder list, string innerText)
        {
            TagBuilder a = new("a");
            a.AddCssClass("page-link");
            a.Attributes.Add("onclick", $@"ChangePage(""{innerText}"", ""{FormId}"")");
            a.InnerHtml.Append(innerText);
            list.InnerHtml.AppendHtml(a);
        }
    }
}
