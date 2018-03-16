using System;
using System.Collections.Generic;
using AppKit;

namespace ToDoList.Model
{
    public class ToDoItemDataSource : NSTableViewDataSource
    {
        private readonly IList<ToDoItem> _items = new List<ToDoItem>();

        public IList<ToDoItem> Items => _items;

        public ToDoItemDataSource()
        {
        }

		public override nint GetRowCount(NSTableView tableView)
		{
            return _items.Count;
		}
	}
}
