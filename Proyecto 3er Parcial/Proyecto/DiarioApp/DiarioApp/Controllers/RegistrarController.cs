// This file has been autogenerated from a class added in the UI designer.

using System;
using Firebase.Auth;
using Foundation;
using UIKit;

namespace DiarioApp
{
	public partial class RegistrarController : UIViewController
	{
		public RegistrarController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            btnAceptar.TouchUpInside += BtnAceptar_TouchUpOutside;

        }

        void BtnAceptar_TouchUpOutside(object sender, EventArgs e)
        {
            var pass1 = "";
            pass1 = txtContrasenia.Text;
            var pass2 = ""; 
            pass2 = txtVerificarContrasenia.Text;
            var correo = "";
            correo = txtCorreo.Text;
            if (pass1 != "" && pass2 != "" && correo != "")
            {
                if (pass1.Equals(pass2))
                {
                    Auth.DefaultInstance.CreateUser(correo, pass1, HandleAuthResult);
                }
                else
                {
                    //Create Alert
                    var okAlertController = UIAlertController.Create("Error", "Contraseñas diferentes", UIAlertControllerStyle.Alert);

                    //Add Action
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                    // Present Alert
                    PresentViewController(okAlertController, true, null);
                }
            }
            else
            {
                UIAlertView _error = new UIAlertView("Campos vacios", "Favor de no dejar campos vacios", null, "Ok", null);

                _error.Show();
            }

        }


        void HandleAuthResult(User user, NSError error)
        {
            if (error != null)
            {
                AuthErrorCode errorCode;
                if (IntPtr.Size == 8) // 64 bits devices
                    errorCode = (AuthErrorCode)((long)error.Code);
                else // 32 bits devices
                    errorCode = (AuthErrorCode)((int)error.Code);

                // Posible error codes that CreateUser method could throw
                switch (errorCode)
                {
                    case AuthErrorCode.InvalidEmail:
                    case AuthErrorCode.EmailAlreadyInUse:
                    case AuthErrorCode.OperationNotAllowed:
                    case AuthErrorCode.WeakPassword:
                    default:
                        // Print error
                        break;
                }

                return;
            }
            // Do your magic to handle authentication result
            txtCorreo.Text = "";
            txtContrasenia.Text = "";
            txtVerificarContrasenia.Text = "";
            //Create Alert
            var okAlertController = UIAlertController.Create("Usuario Agregado", "Usuario agregado correctamente", UIAlertControllerStyle.Alert);

            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            // Present Alert
            PresentViewController(okAlertController, true, null);
        }
	}
}
