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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnIcons8 { get; set; }

		[Outlet]
		UIKit.UIButton btnIniciarSesion { get; set; }

		[Outlet]
		UIKit.UIButton btnRegistrar { get; set; }

		[Outlet]
		UIKit.UITextField txtPassword { get; set; }

		[Outlet]
		UIKit.UITextField txtUser { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnIniciarSesion != null) {
				btnIniciarSesion.Dispose ();
				btnIniciarSesion = null;
			}

			if (btnRegistrar != null) {
				btnRegistrar.Dispose ();
				btnRegistrar = null;
			}

			if (txtPassword != null) {
				txtPassword.Dispose ();
				txtPassword = null;
			}

			if (txtUser != null) {
				txtUser.Dispose ();
				txtUser = null;
			}

			if (btnIcons8 != null) {
				btnIcons8.Dispose ();
				btnIcons8 = null;
			}
		}
	}
}
