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
	[Register ("DayController")]
	partial class DayController
	{
		[Outlet]
		UIKit.UIButton btnGuardarDia { get; set; }

		[Outlet]
		UIKit.UIButton btnImage { get; set; }

		[Outlet]
		UIKit.UIImageView imgAdjunto { get; set; }

		[Outlet]
		UIKit.UILabel lbldato { get; set; }

		[Outlet]
		UIKit.UITextField lblTitulo { get; set; }

		[Outlet]
		UIKit.UITextField txtDato { get; set; }

		[Outlet]
		UIKit.UITextView txtDescripcion { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGuardarDia != null) {
				btnGuardarDia.Dispose ();
				btnGuardarDia = null;
			}

			if (btnImage != null) {
				btnImage.Dispose ();
				btnImage = null;
			}

			if (imgAdjunto != null) {
				imgAdjunto.Dispose ();
				imgAdjunto = null;
			}

			if (lbldato != null) {
				lbldato.Dispose ();
				lbldato = null;
			}

			if (txtDescripcion != null) {
				txtDescripcion.Dispose ();
				txtDescripcion = null;
			}

			if (lblTitulo != null) {
				lblTitulo.Dispose ();
				lblTitulo = null;
			}

			if (txtDato != null) {
				txtDato.Dispose ();
				txtDato = null;
			}
		}
	}
}
