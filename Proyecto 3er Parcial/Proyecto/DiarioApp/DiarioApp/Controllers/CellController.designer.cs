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
	[Register ("CellController")]
	partial class CellController
	{
		[Outlet]
		UIKit.UIImageView imgAdjunto { get; set; }

		[Outlet]
		UIKit.UIImageView imgMes { get; set; }

		[Outlet]
		UIKit.UILabel lblDescripcion { get; set; }

		[Outlet]
		UIKit.UILabel lblDiaM { get; set; }

		[Outlet]
		UIKit.UILabel lblTitulo { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblTitulo != null) {
				lblTitulo.Dispose ();
				lblTitulo = null;
			}

			if (lblDescripcion != null) {
				lblDescripcion.Dispose ();
				lblDescripcion = null;
			}

			if (imgMes != null) {
				imgMes.Dispose ();
				imgMes = null;
			}

			if (lblDiaM != null) {
				lblDiaM.Dispose ();
				lblDiaM = null;
			}

			if (imgAdjunto != null) {
				imgAdjunto.Dispose ();
				imgAdjunto = null;
			}
		}
	}
}
