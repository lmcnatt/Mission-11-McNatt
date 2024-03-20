using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
using Mission11McNatt.Models.ViewModels;

namespace TheWaterProject.Infrastructure
{
  [HtmlTargetElement("div", Attributes="page-model")]
  public class PaginationTagHelper : TagHelper
  {
    private IUrlHelperFactory urlHelperFactory;

    public PaginationTagHelper (IUrlHelperFactory temp)
    {
      urlHelperFactory = temp;
    }

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; }
    public string? PageAction { get; set; }
    public PaginationInfo PageModel { get; set; }

    public bool PageClassesEnabled { get; set; } = false;
    public string PageClass { get; set; } = string.Empty;
    public string PageClassNormal { get; set; } = string.Empty;
    public string PageClassSelected { get; set; } = string.Empty;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      if (ViewContext != null && PageModel != null)
      {
        IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

        TagBuilder result = new TagBuilder("div");
        TagBuilder ul = new TagBuilder("ul");
        ul.Attributes["class"] = "pagination";

        for (int i = 1; i <= PageModel.TotalNumPages; i++)
        {
          TagBuilder li = new TagBuilder("li");
          TagBuilder a = new TagBuilder("a");
          a.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });
          a.Attributes["class"] = "page-link";

          // if (PageClassesEnabled) // From videos
          {
            a.AddCssClass(PageClass);
            a.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
          }

          a.InnerHtml.Append(i.ToString());

          li.Attributes["class"] = "page-item";
          li.InnerHtml.AppendHtml(a);
          // result.InnerHtml.AppendHtml(a); // Videos
        }
        result.InnerHtml.AppendHtml(ul);

        output.Content.AppendHtml(result.InnerHtml);
      }
    }
  }
}