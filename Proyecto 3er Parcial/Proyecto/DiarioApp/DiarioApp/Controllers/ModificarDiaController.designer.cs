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
	[Register ("ModificarDiaController")]
	partial class ModificarDiaController
	{
		[Outlet]
		UIKit.UIButton btnGuardarDiaM { get; set; }

		[Outlet]
		UIKit.UIButton btnImageM { get; set; }

		[Outlet]
		UIKit.UIImageView imgAdjuntoM { get; set; }

		[Outlet]
		UIKit.UILabel lblDatoM { get; set; }

		[Outlet]
		UIKit.UITextField txtDatoM { get; set; }

		[Outlet]
		UIKit.UITextView txtDescripcionM { get; set; }

		[Outlet]
		UIKit.UITextField txtTituloM { get; set; }

		[Action ("btnBorrar:")]
		partial void btnBorrar (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (txtTituloM != null) {
				txtTituloM.Dispose ();
				txtTituloM = null;
			}

			if (txtDescripcionM != null) {
				txtDescripcionM.Dispose ();
				txtDescripcionM = null;
			}

			if (btnImageM != null) {
				btnImageM.Dispose ();
				btnImageM = null;
			}

			if (txtDatoM != null) {
				txtDatoM.Dispose ();
				txtDatoM = null;
			}

			if (imgAdjuntoM != null) {
				imgAdjuntoM.Dispose ();
				imgAdjuntoM = null;
			}

			if (lblDatoM != null) {
				lblDatoM.Dispose ();
				lblDatoM = null;
			}

			if (btnGuardarDiaM != null) {
				btnGuardarDiaM.Dispose ();
				btnGuardarDiaM = null;
			}
		}
	}
}
