// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ExamenParcialDos
{
	[Register ("TableViewController")]
	partial class TableViewController
	{
		[Outlet]
		UIKit.UITableView tblView { get; set; }

		[Action ("btn_Icons:")]
		partial void btn_Icons (Foundation.NSObject sender);

		[Action ("btn_pajaro:")]
		partial void btn_pajaro (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (tblView != null) {
				tblView.Dispose ();
				tblView = null;
			}
		}
	}
}
