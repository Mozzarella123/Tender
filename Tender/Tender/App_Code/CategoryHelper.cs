using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;

namespace TenderApp.App_Code
{
    public static class CategoryHelper
    {
        static IHtmlHelper html;
        public static HtmlString Cat(this IHtmlHelper html, IEnumerable<Category> categories)
        {
            CategoryHelper.html = html;
            TagBuilder result;
            List<int> donecats = new List<int>();
            result = new TagBuilder("table");
            result.Attributes["class"] = "table table-striped table-sm table-bordered text-center";
            HierarchyList(categories);
            void HierarchyList(IEnumerable<Category> cats, string tab = "")
            {
                foreach (Category cat in cats)
                {
                    if (!donecats.Contains(cat.CategoryId))
                    {
                        TagBuilder tr = new TagBuilder("tr");
                        TagBuilder[] tds = new TagBuilder[4];
                        for (int i = 0; i < 4; i++)
                            tds[i] = new TagBuilder("td");
                        tds[0].InnerHtml.Append(tab + cat.Name);
                        tds[0].Attributes["class"] = "text-left";
                        tds[1].InnerHtml.Append(cat.Description);
                        TagBuilder form = new TagBuilder("form");
                        TagBuilder form1 = new TagBuilder("form");
                        form.Attributes.Add("method", "get");
                        form.Attributes.Add("action", "CategoryManage/Edit/" + cat.CategoryId.ToString());
                        TagBuilder button = new TagBuilder("button");
                        TagBuilder button1 = new TagBuilder("button");
                        var form3 = html.BeginForm("Edit", "CategoryManage", new { Id = cat.CategoryId }, FormMethod.Get);
                        

                        button.Attributes.Add("type", "submit");
                        button1.Attributes.Add("type", "submit");
                        button.Attributes.Add("class", "btn btn-primary");
                        button.InnerHtml.Append("Редактировать");
                        form.InnerHtml.SetHtmlContent(button);
                        tds[2].InnerHtml.AppendHtml(form);
                        form1.Attributes["method"] = "post";
                        form1.Attributes["action"] = "CategoryManage/Delete/" + cat.CategoryId.ToString();
                        button1.Attributes["class"] = "btn btn-danger needconfirm";
                        button1.InnerHtml.SetContent("Удалить");
                        form1.InnerHtml.SetHtmlContent(button1);
                        tds[3].InnerHtml.AppendHtml(form1);
                        for (int i = 0; i < 4; i++)
                            tr.InnerHtml.AppendHtml(tds[i]);
                        result.InnerHtml.AppendHtml(tr);
                        donecats.Add(cat.CategoryId);
                        if (cat.Children != null)
                            HierarchyList(cat.Children, tab + "--");
                    }
                }
            }
            var writer = new System.IO.StringWriter();
            result.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());

        }
        //public static HtmlString ParentSelect(this IHtmlHelper, IEnumerable<Category> categories)
        //{
        //    TagBuilder select = new TagBuilder("select");
        //}
    }
}
