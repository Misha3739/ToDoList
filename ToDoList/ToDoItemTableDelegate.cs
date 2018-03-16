using System;
using AppKit;
using ToDoList.Model;

namespace ToDoList
{
    public class ToDoItemTableDelegate : NSTableViewDelegate
    {
        private ToDoItemDataSource _dataSource;

        private const string c_cellIdentifier = "ToDoItemCell";

        public ToDoItemTableDelegate(ToDoItemDataSource dataSource)
        {
            this._dataSource = dataSource;
        }

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
            NSTextField view = (NSTextField)tableView.MakeView(c_cellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = c_cellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            // Setup view based on the column selected
            switch (tableColumn.Title)
            {
                case "Name":
                    view.StringValue = _dataSource.Items[(int)row].Name;
                    break;
                case "Important":
                    view.StringValue = _dataSource.Items[(int)row].IsImportant.ToString();
                    break;
            }

            return view;
		}


	}
}
