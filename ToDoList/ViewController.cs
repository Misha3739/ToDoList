using System;
using System.Diagnostics;

using AppKit;
using Foundation;

namespace ToDoList
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

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

        partial void AddButtonClick(Foundation.NSObject sender)
        {
            if (string.IsNullOrEmpty(TextField.StringValue))
            {
                //(NSApplication.SharedApplication.Delegate as AppDelegate)?.Sel
                var todoItem =  new ToDoItem()
                {
                    Name = TextField.StringValue,
                    IsImportant = ImportantCheckBox.IntValue == 1
                }
            
            }
        }
    }
}
