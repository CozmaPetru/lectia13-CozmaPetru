using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoLab.Helpers
{
    public static class AutoHelpers
    {
        // Se apelează în vedere ca @Html.Insigna("Hibrid").
        // Produce: <span class="badge text-bg-info" title="Combustibil: Hibrid">Hibrid</span>
        public static IHtmlContent Insigna(this IHtmlHelper html, string combustibil)
        {
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("badge");

            if (combustibil == "Electric")
            {
                span.AddCssClass("text-bg-success");
            }
            else if (combustibil == "Hibrid")
            {
                span.AddCssClass("text-bg-info");
            }
            else
            {
                span.AddCssClass("text-bg-secondary");
            }

            span.MergeAttribute("title", "Combustibil: " + combustibil);
            span.InnerHtml.Append(combustibil);
            return span;
        }
    }
}
