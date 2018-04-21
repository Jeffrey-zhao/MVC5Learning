using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml.Linq;

namespace WebAppHtmlTemplate.Customs
{
    public static class ListControlExtensions
    {
        public  static MvcHtmlString RadioButtonList(
            this HtmlHelper htmlHelper,
            string name,
            string listName,
            string value
            )
        {
            return RadioButtonCheckBoxList(htmlHelper, listName, item => htmlHelper.RadioButton(name, item.Value, value == item.Value));
        }

        public static MvcHtmlString CheckBoxList(
            this HtmlHelper htmlHelper,
            string name,
            string listName,
            IEnumerable<string> values
            )
        {
            return RadioButtonCheckBoxList(htmlHelper, listName, item => CheckBoxWithValue(htmlHelper,name,values.Contains(item.Value),item.Value));
        }

        public static MvcHtmlString CheckBoxWithValue(HtmlHelper htmlHelper, string name, bool isChecked, string value)
        {
            string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            ModelState modelState;
            if(htmlHelper.ViewData.ModelState.TryGetValue(fullHtmlFieldName,out modelState))
            {
                htmlHelper.ViewData.ModelState.SetModelValue(fullHtmlFieldName, new ValueProviderResult(isChecked, isChecked.ToString(), CultureInfo.CurrentCulture));
            }
            MvcHtmlString html;
            try
            {
                html = htmlHelper.CheckBox(name, isChecked);
            }
            finally
            {
                if (null != modelState)
                {
                    htmlHelper.ViewData.ModelState[fullHtmlFieldName] = modelState;
                }
            }
            string htmlString = html.ToHtmlString();
            var index = htmlString.LastIndexOf('<');
            XElement element = XElement.Parse(htmlString.Substring(0, index));
            element.SetAttributeValue("value", value);
            return new MvcHtmlString(element.ToString());
        }

        public static MvcHtmlString ListBox(
            this HtmlHelper htmlHelper,
            string name,
            string listName,
            IEnumerable<string> values
            )
        {
            var listItems = ListProviders.Current.GetListItems(listName);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in listItems)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text=item.Text,
                    Value=item.Value,
                    Selected=values.Any(value=>value==item.Value)
                });
            }
            return htmlHelper.ListBox(name, selectListItems);
        }

        public static MvcHtmlString DropDownList(
            this HtmlHelper htmlHelper,
            string name,
            string listName,
            string value
            )
        {
            var listItems = ListProviders.Current.GetListItems(listName);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in listItems)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = item.Text,
                    Value = item.Value,
                    Selected = value == item.Value
                });
            }
            return htmlHelper.DropDownList(name, selectListItems);
        }

        private static MvcHtmlString RadioButtonCheckBoxList(HtmlHelper htmlHelper, string listName, Func<ListItem, MvcHtmlString> p)
        {
            var listItems = ListProviders.Current.GetListItems(listName);
            TagBuilder table = new TagBuilder("table");
            TagBuilder tr = new TagBuilder("tr");
            foreach (var listItem in listItems)
            {
                TagBuilder td = new TagBuilder("td");
                td.InnerHtml += p(listItem).ToHtmlString();
                td.InnerHtml += listItem.Text;
                tr.InnerHtml += td.ToString();
            }
            table.InnerHtml = tr.ToString();
            return new MvcHtmlString(table.ToString());
        }
    }
}