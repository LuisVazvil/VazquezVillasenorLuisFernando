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
	[Register ("TweetsCell")]
	partial class TweetsCell
	{
		[Outlet]
		UIKit.UIImageView imgLike { get; set; }

		[Outlet]
		UIKit.UILabel lblLiked { get; set; }

		[Outlet]
		UIKit.UILabel lblTweet { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgLike != null) {
				imgLike.Dispose ();
				imgLike = null;
			}

			if (lblLiked != null) {
				lblLiked.Dispose ();
				lblLiked = null;
			}

			if (lblTweet != null) {
				lblTweet.Dispose ();
				lblTweet = null;
			}
		}
	}
}
