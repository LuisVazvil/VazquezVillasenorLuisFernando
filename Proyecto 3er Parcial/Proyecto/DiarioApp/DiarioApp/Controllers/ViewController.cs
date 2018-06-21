using System;
using UIKit;
using Foundation;
using Firebase.Core;
using Firebase.Auth;
using Google.SignIn;

namespace DiarioApp
{
    public partial class ViewController : UIViewController
    {
        string email;
        string password;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            btnIniciarSesion.TouchUpInside += BtnIniciarSesion_TouchUpInside;
            btnIcons8.TouchUpInside += BtnIcons8_TouchUpInside;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void BtnIcons8_TouchUpInside(object sender, EventArgs e)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl("https://icons8.com"));
        }


        void BtnIniciarSesion_TouchUpInside(object sender, EventArgs e)
        {
            //Login();
            email = txtUser.Text.ToString();
            password = txtPassword.Text.ToString();
            if (email != null && password != null)
            {
                
                Auth.DefaultInstance.SignIn(email, password, HandleAuthResult);
            }
            else
            {
                UIAlertView _error = new UIAlertView("Campos vacios", "Favor de no dejar campos vacios ", null, "Ok", null);

                _error.Show();
            }


        }

        /*public void Login()
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
        }*/

        void HandleAuthResult(User user, NSError error)
        {
            if (error != null)
            {
                AuthErrorCode errorCode;
                if (IntPtr.Size == 8) // 64 bits devices
                    errorCode = (AuthErrorCode)((long)error.Code);
                else // 32 bits devices
                    errorCode = (AuthErrorCode)((int)error.Code);

                // Posible error codes that SignIn method with email and password could throw
                // Visit https://firebase.google.com/docs/auth/ios/errors for more information
                switch (errorCode)
                {
                    case AuthErrorCode.OperationNotAllowed:
                    case AuthErrorCode.InvalidEmail:
                    case AuthErrorCode.UserDisabled:
                    case AuthErrorCode.WrongPassword:
                    default:
                        // Print error
                        break;
                }
                UIAlertView _error = new UIAlertView("Error en Login", "Usuario y/o contraseña erroneos ", null, "Ok", null);

                _error.Show();
                return;
            }

            var controller = Storyboard.InstantiateViewController(nameof(TableController));

            AppDelegate.UserUid = user.Uid;
            // Do your magic to handle authentication result
            txtUser.Text = "";
            txtPassword.Text = "";
            this.NavigationController.PushViewController(controller, true);
        }

    }
}
