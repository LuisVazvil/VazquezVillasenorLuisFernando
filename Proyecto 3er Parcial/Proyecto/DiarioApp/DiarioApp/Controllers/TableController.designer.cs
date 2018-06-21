// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DiarioApp
{
	[Register ("TableController")]
	partial class TableController
	{
		[Outlet]
		UIKit.UITableView tableList { get; set; }

		[Action ("btnAgregarDia:")]
		partial void btnAgregarDia (Foundation.NSObject sender);

		[Action ("btnCalendario:")]
		partial void btnCalendario (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (tableList != null) {
				tableList.Dispose ();
				tableList = null;
			}
		}
	}
}
