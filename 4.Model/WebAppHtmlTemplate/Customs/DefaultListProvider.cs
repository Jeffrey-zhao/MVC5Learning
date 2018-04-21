using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHtmlTemplate.Customs
{
    public class DefaultListProvider : IListProvider
    {
        private static Dictionary<string, IEnumerable<ListItem>> ListItems
            = new Dictionary<string, IEnumerable<ListItem>>();
        static DefaultListProvider()
        {
            var items = new ListItem[]
            {
                new ListItem {Text="男",Value="M" },
                new ListItem {Text="女",Value="F" },
            };
            ListItems.Add("Gender", items);

            items = new ListItem[]
            {
                new ListItem {Text="高中",Value="H" },
                new ListItem {Text="大学本科",Value="B" },
                new ListItem {Text="硕士",Value="M" },
                new ListItem {Text="博士",Value="D" },
            };
            ListItems.Add("Education", items);

            items = new ListItem[]
            {
                new ListItem {Text="第一开发部",Value="Dev1" },
                new ListItem {Text="第二开发部",Value="Dev2" },
                new ListItem {Text="第三开发部",Value="Dev3" },
            };
            ListItems.Add("Department", items);

            items = new ListItem[]
            {
                new ListItem {Text="C#",Value="C#" },
                new ListItem {Text="Asp.Net",Value="Asp.Net" },
                new ListItem {Text="Ado.Net",Value="Ado.Net" },
                new ListItem {Text="EF",Value="EF" },
            };
            ListItems.Add("Skill", items);
        }
        public IEnumerable<ListItem> GetListItems(string listName)
        {
            IEnumerable<ListItem> items;
            if(ListItems.TryGetValue(listName,out items))
            {
                return items;
            }
            return new ListItem[0];
        }
    }
}