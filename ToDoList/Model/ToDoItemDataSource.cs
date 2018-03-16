using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace ToDoList.Model
{
    public class ToDoItemDataSource : NSTableViewDataSource
    {
        private readonly List<ToDoItem> _items = new List<ToDoItem>();

        public List<ToDoItem> Items => _items;

        public ToDoItemDataSource()
        {
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return Items.Count;
        }


        public void Sort(string key, bool ascending)
        {

            // Take action based on key
            switch (key)
            {
                case "Name":
                    if (ascending)
                    {
                        Items.Sort((x, y) => x.Name.CompareTo(y.Name));
                    }
                    else
                    {
                        Items.Sort((x, y) => -1 * x.Name.CompareTo(y.Name));
                    }
                    break;
                case "Important":
                    if (ascending)
                    {
                        Items.Sort((x, y) => x.IsImportant.CompareTo(y.IsImportant));
                    }
                    else
                    {
                        Items.Sort((x, y) => -1 * x.IsImportant.CompareTo(y.IsImportant));
                    }
                    break;
            }

        }

        public override void SortDescriptorsChanged(NSTableView tableView, NSSortDescriptor[] oldDescriptors)
        {
            // Sort the data
            if (oldDescriptors.Length > 0)
            {
                // Update sort
                Sort(oldDescriptors[0].Key, oldDescriptors[0].Ascending);
            }
            else
            {
                // Grab current descriptors and update sort
                NSSortDescriptor[] tbSort = tableView.SortDescriptors;
                Sort(tbSort[0].Key, tbSort[0].Ascending);
            }

            // Refresh table
            tableView.ReloadData();
        }
    }
}
