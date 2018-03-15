// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ToDoList
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSButton AddButton { get; set; }

        [Outlet]
        AppKit.NSButton ImportantCheckBox { get; set; }

        [Outlet]
        AppKit.NSTextField TextField { get; set; }

        [Action ("AddButtonClick:")]
        partial void AddButtonClick (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (TextField != null) {
                TextField.Dispose ();
                TextField = null;
            }

            if (ImportantCheckBox != null) {
                ImportantCheckBox.Dispose ();
                ImportantCheckBox = null;
            }

            if (AddButton != null) {
                AddButton.Dispose ();
                AddButton = null;
            }
        }
    }
}
