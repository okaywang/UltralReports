using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Website.Models
{
    public class ModalModel
    {
        public string Title { get; set; }

        public IEnumerable<PropertyInfo> Properties { get; set; }
    }

    public class ModalModel<T> : IModalModel<T>
    {
        public string Title { get; set; }

        public T DataModel { get { return default(T); } }
    }

    public interface IModalModel<out T>
    {
        string Title { get; set; }

        T DataModel { get; }
    }

    public class ListPageModal
    {
        public string Title { get; set; }

        public string RequestListUrl { get; set; }
    }

    public interface IListItem
    {
        string Serialize();
    }

    public interface IListItemCommands
    {
        IListItemCommand[] Commands { get; }
    }

    public interface IListItemCommand
    {
        string CommandName { get; }
        string CommandText { get; }
        string CommandAction { get; }
    }

    public class ListItemCommand : IListItemCommand
    {
        public ListItemCommand(string name, string text, string url)
        {
            this.CommandName = name;
            this.CommandText = text;
            this.CommandAction = url;
        }
        public string CommandName { get; private set; }
        public string CommandText { get; private set; }
        public string CommandAction { get; private set; }
    }
}