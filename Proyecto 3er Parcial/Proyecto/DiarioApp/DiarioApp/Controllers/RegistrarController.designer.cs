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
	[Register ("RegistrarController")]
	partial class RegistrarController
	{
		[Outlet]
		UIKit.UIButton btnAceptar { get; set; }

		[Outlet]
		UIKit.UITextField txtContrasenia { get; set; }

		[Outlet]
		UIKit.UITextField txtCorreo { get; set; }

		[Outlet]
		UIKit.UITextField txtVerificarContrasenia { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtCorreo != null) {
				txtCorreo.Dispose ();
				txtCorreo = null;
			}

			if (txtContrasenia != null) {
				txtContrasenia.Dispose ();
				txtContrasenia = null;
			}

			if (txtVerificarContrasenia != null) {
				txtVerificarContrasenia.Dispose ();
				txtVerificarContrasenia = null;
			}

			if (btnAceptar != null) {
				btnAceptar.Dispose ();
				btnAceptar = null;
			}
		}
	}
}
