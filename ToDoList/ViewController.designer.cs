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
		AppKit.NSTableColumn ImportantColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn NameColumn { get; set; }

		[Outlet]
		AppKit.NSTextField TextField { get; set; }

		[Outlet]
		AppKit.NSTableView ToDoTable { get; set; }

		[Action ("AddButtonClick:")]
		partial void AddButtonClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (AddButton != null) {
				AddButton.Dispose ();
				AddButton = null;
			}

			if (ImportantCheckBox != null) {
				ImportantCheckBox.Dispose ();
				ImportantCheckBox = null;
			}

			if (TextField != null) {
				TextField.Dispose ();
				TextField = null;
			}

			if (ToDoTable != null) {
				ToDoTable.Dispose ();
				ToDoTable = null;
			}

			if (NameColumn != null) {
				NameColumn.Dispose ();
				NameColumn = null;
			}

			if (ImportantColumn != null) {
				ImportantColumn.Dispose ();
				ImportantColumn = null;
			}
		}
	}
}
