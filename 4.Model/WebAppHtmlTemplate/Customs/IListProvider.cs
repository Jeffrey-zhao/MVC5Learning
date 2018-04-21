using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHtmlTemplate.Customs
{
    public interface IListProvider
    {
        IEnumerable<ListItem> GetListItems(string listName);
    }
}