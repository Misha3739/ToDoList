using System;
using AppKit;
using CoreGraphics;
using ToDoList.Model;

namespace ToDoList
{
    public class ToDoItemTableDelegate : NSTableViewDelegate
    {
        private readonly ToDoItemDataSource _dataSource;

        private readonly ViewController _viewController;

        private const string c_cellIdentifier = "ToDoItemCell";

        public ToDoItemTableDelegate(ToDoItemDataSource dataSource, ViewController viewController)
        {
            this._dataSource = dataSource;
            this._viewController = viewController;
        }

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
            NSTableCellView view = (NSTableCellView)tableView.MakeView(tableColumn.Title, this);
            if (view == null)
            {
                view = new NSTableCellView();
                view.Identifier = tableColumn.Title;

                switch (tableColumn.Title)
                {
                    
                    case "Delete":
                        var button = new NSButton(new CGRect(0, 0, 81, 16));
                        button.SetButtonType(NSButtonType.MomentaryPushIn);
                        button.Title = "Delete";
                        button.Tag = row;

                        // Wireup events
                        button.Activated += (sender, e) => {
                            // Get button and product
                            var btw = sender as NSButton;
                            var toDoItem = _dataSource.Items[(int)button.Tag];

                            // Configure alert
                            var alert = new NSAlert()
                            {
                                AlertStyle = NSAlertStyle.Informational,
                                InformativeText = $"Are you sure you want to delete {toDoItem.Name}? This operation cannot be undone.",
                                MessageText = $"Delete {toDoItem.Name}?",
                            };
                            alert.AddButton("Cancel");
                            alert.AddButton("Delete");
                            alert.BeginSheetForResponse(_viewController.View.Window, (result) => {
                                // Should we delete the requested row?
                                if (result == 1001)
                                {
                                    // Remove the given row from the dataset
                                    _dataSource.Items.RemoveAt((int)button.Tag);
                                    _viewController.ReloadTable();
                                }
                            });
                        };

                        // Add to view
                        //view.AddSubview(button);
                        break;
                    default:
                        view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
                        view.TextField.Identifier = c_cellIdentifier;
                        ConfigureTextField(view,row);
                        break;
                }

            }

            // Setup view based on the column selected
            switch (tableColumn.Title)
            {
                case "Name":
                    view.TextField.StringValue = _dataSource.Items[(int)row].Name;
                    break;
                case "Important":
                    view.TextField.StringValue = _dataSource.Items[(int)row].IsImportant.ToString();
                    break;
            }

            return view;
		}


        private void ConfigureTextField(NSTableCellView view, nint row)
        {
            // Add to view
            view.TextField.AutoresizingMask = NSViewResizingMask.WidthSizable;
            view.AddSubview(view.TextField);

            // Configure
            view.TextField.BackgroundColor = NSColor.Clear;
            view.TextField.Bordered = false;
            view.TextField.Selectable = false;
            view.TextField.Editable = true;

            // Wireup events
            view.TextField.EditingEnded += (sender, e) => {

                // Take action based on type
                switch (view.Identifier)
                {
                    case "Name":
                        _dataSource.Items[(int)view.TextField.Tag].Name = view.TextField.StringValue;
                        break;
                    case "Important":
                        _dataSource.Items[(int)view.TextField.Tag].IsImportant = view.TextField.StringValue.ToUpper() == "TRUE";
                        break;
                }
            };

            // Tag view
            view.TextField.Tag = row;
        }


	}
}
