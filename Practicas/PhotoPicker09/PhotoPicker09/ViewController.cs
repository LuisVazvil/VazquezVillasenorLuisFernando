using System;
using System.Threading.Tasks;
using UIKit;
using Photos;
using Foundation;
using AVFoundation;

namespace PhotoPicker09
{
    public partial class ViewController : UIViewController, IUIImagePickerControllerDelegate
    {
        #region Class Variables
        UITapGestureRecognizer profileTapGesture;
        UITapGestureRecognizer coverTapGesture;

        #endregion
        #region Constructors

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }


        #endregion
        #region Controller Life Cycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            InitializeComponents();
            btnEdit.Clicked+= MostrarEditar;
        }
        #endregion

        #region User Interactions

        void ShowOptions(UITapGestureRecognizer gesture){
            var alert = UIAlertController.Create(null, null, UIAlertControllerStyle.ActionSheet);

            alert.AddAction(UIAlertAction.Create("Tomar Foto", UIAlertActionStyle.Default, action => TryOpenCamera()));
            alert.AddAction(UIAlertAction.Create("Abrir galeria", UIAlertActionStyle.Default, action => TryOpenLibrary()));
            alert.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel, null ));

            PresentViewController(alert, animated: true, completionHandler: null);
        }

        #endregion


        #region Internal Functionality
        void InitializeComponents()
        {
            lblProfile.Hidden = lblCover.Hidden = true;

            ActivarFuncionalidad(false);

        }

        void MostrarEditar(object sender, EventArgs e)
        {
            if (lblCover.Hidden==true)
            {
                lblCover.Hidden = false;
                lblProfile.Hidden = false;
                ActivarFuncionalidad(true);

            }
            else
            {
                lblCover.Hidden = true;
                lblProfile.Hidden = true;
                ActivarFuncionalidad(false);
            }
        }


        void ActivarFuncionalidad(bool activado)
        {
            profileTapGesture = new UITapGestureRecognizer(ShowOptions) { Enabled = activado };
            profileView.AddGestureRecognizer(profileTapGesture);

            coverTapGesture = new UITapGestureRecognizer(ShowOptions) { Enabled = activado };
            CoverView.AddGestureRecognizer(coverTapGesture);
        }

        void ShowMessage(string title, string message, UIViewController fromViewController)
        {
            var alert = UIAlertController.Create(title, message , UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default,null));
                            fromViewController.PresentViewController(alert,true,null);
        }

        void TryOpenLibrary(){
            CheckPhotoLibraryAutorizationStatus (PHPhotoLibrary.AuthorizationStatus );
        }

        void CheckPhotoLibraryAutorizationStatus(PHAuthorizationStatus authorizationStatus)
        {
            switch (authorizationStatus)
            {
                case PHAuthorizationStatus.NotDetermined:
                    PHPhotoLibrary.RequestAuthorization(CheckPhotoLibraryAutorizationStatus);
                    break;
                case PHAuthorizationStatus.Restricted:
                    InvokeOnMainThread(() => ShowMessage("Acceso Restringido", "", NavigationController));
                    break;
                case PHAuthorizationStatus.Denied:
                    InvokeOnMainThread(() => ShowMessage("Acceso Denegado", "", NavigationController));

                    break;
                case PHAuthorizationStatus.Authorized:
                    InvokeOnMainThread(() =>
                    {
                        var imagePickerController = new UIImagePickerController
                        {
                            SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                            Delegate = this                                              
                        };
                        PresentViewController(imagePickerController, true, null);
                    });


                    break;
                default:
                    break;
            }
        }

        void TryOpenCamera(){
            if (!UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
            {
                ShowMessage("Error","La Camara no esta disponible", NavigationController);
                return;
            }
            AVAuthorizationStatus authStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);
            CheckCamaraAutorizationStatus(authStatus);



        }


        async private void CheckCamaraAutorizationStatus(AVAuthorizationStatus authorizationStatus)
        {
            switch (authorizationStatus)
            {
                case AVAuthorizationStatus.NotDetermined:
                    await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
                    CheckCamaraAutorizationStatus(authorizationStatus);
                   break;
                case AVAuthorizationStatus.Restricted:
                    InvokeOnMainThread(() => ShowMessage("Acceso a Camara Restringido", "Por que no muestras los packs??? Te quieres morir??", NavigationController));
                    break;
                case AVAuthorizationStatus.Denied:
                    InvokeOnMainThread(() => ShowMessage("Acceso a Camara Denegado", "Por que no muestras los packs??? Te quieres morir??", NavigationController));
                    break;
                case AVAuthorizationStatus.Authorized:
                    InvokeOnMainThread(() =>
                    {
                        var imagePickerController = new UIImagePickerController
                        {
                            SourceType = UIImagePickerControllerSourceType.Camera,
                            Delegate = this
                        };
                        PresentViewController(imagePickerController, true, null);
                    });

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [Export("imagePickerController:didFinishPickingMediaWithInfo:")]
        public void FinishedPickingMedia(UIImagePickerController picker, Foundation.NSDictionary info)
        {
            var image = info [UIImagePickerController.OriginalImage] as UIImage;

            imgProfile.Image = image;
            imgCover.Image = image;
            picker.DismissViewController(true, null);
        }



        [ExportAttribute("imagePickerControllerDidCancel:")]
        public void Canceled(UIImagePickerController picker)
        {
            picker.DismissViewController(true,null);
        }

        #endregion
    }
}
