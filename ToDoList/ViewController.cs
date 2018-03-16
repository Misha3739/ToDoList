using System;
using System.Diagnostics;

using AppKit;
using Foundation;
using ToDoList.Model;

namespace ToDoList
{
    public partial class ViewController : NSViewController
    {
        private readonly ToDoItemDataSource _dataSource;

        public ViewController(IntPtr handle) : base(handle)
        {
            _dataSource = new ToDoItemDataSource();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.ToDoTable.DataSource = _dataSource;
            this.ToDoTable.Delegate = new ToDoItemTableDelegate(_dataSource, this);
            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        private void AddDummyData()
        {
            ToDoItem item = new ToDoItem("First item", true);
            this._dataSource.Items.Add(item);
        }

		public override void AwakeFromNib()
		{
            base.AwakeFromNib();

            //AddDummyData();


		}

		partial void AddButtonClick(Foundation.NSObject sender)
        {
            if (!string.IsNullOrEmpty(TextField.StringValue))
            {
                //(NSApplication.SharedApplication.Delegate as AppDelegate)?.Sel
                var todoItem = new ToDoItem()
                {
                    Name = TextField.StringValue,
                    IsImportant = ImportantCheckBox.IntValue == 1
                };
                this._dataSource.Items.Add(todoItem);
                ToDoTable.ReloadData();

                ClearData();
            }
        }

        public void ReloadTable()
        {
            ToDoTable.ReloadData();
        }

        private void ClearData()
        {
            this.ImportantCheckBox.IntValue = 0;
            this.TextField.StringValue = "";
        }

		protected override void Dispose(bool disposing)
		{
            //Dispose datasource
            _dataSource.Dispose();
            base.Dispose(disposing);
		}
	}
}
