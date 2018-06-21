// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using CoreGraphics;
using DiarioApp.Models;
using Firebase.Database;
using Foundation;
using Photos;
using UIKit;

namespace DiarioApp
{
	public partial class ModificarDiaController : UIViewController
	{
		public ModificarDiaController (IntPtr handle) : base (handle)
		{
		}
        DatabaseReference rootNode;
        DatabaseReference userNode;
        string emocionT;
        string foto;
        PickerModel pickerModel;
        public string[] emocion = new string[] {
            "Emocionante",
            "Divertido",
            "Triste",
            "Estresante",
            "Alegre",
            "Cansado",
            "Indiferente"
        };

        public List<Dia> DiasM { get; set; }
        public Dia diaM { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            #region ComboBox
            UIPickerView pickerView = new UIPickerView();

            pickerModel = new PickerModel(lblDatoM, emocion);
            pickerView.Model = pickerModel;



            // Instanciar un toolbar
            UIToolbar toolbar = new UIToolbar();
            toolbar.BarStyle = UIBarStyle.Default;

            //Crear un label
            var labelTitulo = new UILabel(new CGRect(x: 0, y: 50, width: 150, height: 20))
            {
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.Gray.ColorWithAlpha(0.5f),
                TextAlignment = UITextAlignment.Left,
                Text = txtDatoM.Placeholder
            };
            labelTitulo.SizeToFit();

            // Crear los UIBarButtonItem de nuestra toolbar
            var tituloCajaTexto = new UIBarButtonItem(labelTitulo);
            var cancelarBoton = new UIBarButtonItem("Cancelar", UIBarButtonItemStyle.Done, (s, e) => { this.txtDatoM.ResignFirstResponder(); });
            var espacioEntreBoton = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null);
            var listoButton = new UIBarButtonItem("Listo", UIBarButtonItemStyle.Done,
                                                             (s, e) =>
                                                             {
                                                                 this.txtDatoM.Text = emocion[pickerView.SelectedRowInComponent(0)];
                                                                 this.txtDatoM.ResignFirstResponder();
                                                             });
            toolbar.SetItems(new UIBarButtonItem[] { cancelarBoton, espacioEntreBoton, tituloCajaTexto, espacioEntreBoton, listoButton }, true);

            toolbar.TranslatesAutoresizingMaskIntoConstraints = false;
            pickerView.TranslatesAutoresizingMaskIntoConstraints = false;

            toolbar.SizeToFit();

            // Tell the textbox to use the picker for input
            this.txtDatoM.InputView = pickerView;

            // Display the toolbar over the pickers
            this.txtDatoM.InputAccessoryView = toolbar;
            #endregion


            rootNode = Database.DefaultInstance.GetRootReference();


            btnGuardarDiaM.TouchUpInside += BtnGuardarDiaM_TouchUpInside;
            btnImageM.TouchUpInside += BtnImageM_TouchUpInside;

            txtTituloM.Text = diaM.Titulo;
            txtDescripcionM.Text = diaM.Descripcion;
            txtDatoM.Text = diaM.Emocion;
            //Descoding
            byte[] encodedDataAsBytes = System.Convert.FromBase64String (diaM.Foto);  
            NSData ImageData = NSData.FromArray(encodedDataAsBytes);  
            var img = UIImage.LoadFromData(ImageData);  
            imgAdjuntoM.Image = img;
            //pickerM.DismissViewController
            lblDatoM.Text = lblDatoM.Text + " " + diaM.Emocion;

        }


        void BtnGuardarDiaM_TouchUpInside(object sender, EventArgs e)
        {
            emocionT = txtDatoM.Text;
            //var currentTime = DateTime.Now;
            var fecha = diaM.Fecha;
            if (imgAdjuntoM.Image != null)
            {
                string encodedString = imgAdjuntoM.Image.AsJPEG(0.23f).GetBase64EncodedString(NSDataBase64EncodingOptions.None);
                foto = encodedString;
            }
            //var fechaEnviar = currentTime.ToString("d", System.Globalization.CultureInfo.GetCultureInfo("es-mx"));
            var fotoE = "";
            fotoE = fotoE + foto;
            var emocionE = "" + emocionT as string;
            var titulo = "";
            titulo = txtTituloM.Text;
            var descripcion = "";
            descripcion = txtDescripcionM.Text;

            if (descripcion != "" && emocionE != "" && titulo != "")
            {
                userNode = rootNode.GetChild("users").GetChild(AppDelegate.UserUid).GetChild("Dia_" + fecha);
                object[] keys = { "Titulo", "Descripcion", "Emocion", "Foto", "Fecha","Estatus" };
                object[] values = { titulo, descripcion, emocionE, fotoE, fecha,"1" };
                var data = NSDictionary.FromObjectsAndKeys(values, keys, keys.Length);

                userNode.SetValue<NSDictionary>(data);

                //txtDescripcionM.Text = "";
                //txtDatoM.Text = "";

                UIAlertView _error = new UIAlertView("Correcto", "Datos actualizados", null, "Ok", null);

                _error.Show();
            }
            else
            {
                UIAlertView _error = new UIAlertView("Campos vacios", "Favor de no dejar campos vacios", null, "Ok", null);

                _error.Show();
            }
        }

        partial void btnBorrar(NSObject sender)
        {
            emocionT = txtDatoM.Text;
            //var currentTime = DateTime.Now;
            var fecha = diaM.Fecha;
            if (imgAdjuntoM.Image != null)
            {
                string encodedString = imgAdjuntoM.Image.AsJPEG(0.23f).GetBase64EncodedString(NSDataBase64EncodingOptions.None);
                foto = encodedString;
            }
            //var fechaEnviar = currentTime.ToString("d", System.Globalization.CultureInfo.GetCultureInfo("es-mx"));
            var fotoE = "";
            fotoE = fotoE + foto;
            var emocionE = "" + emocionT as string;
            var titulo = "";
            titulo = txtTituloM.Text;
            var descripcion = "";
            descripcion = txtDescripcionM.Text;

                userNode = rootNode.GetChild("users").GetChild(AppDelegate.UserUid).GetChild("Dia_" + fecha);
                object[] keys = { "Titulo", "Descripcion", "Emocion", "Foto", "Fecha", "Estatus" };
                object[] values = { titulo, descripcion, emocionE, fotoE, fecha, "0" };
                var data = NSDictionary.FromObjectsAndKeys(values, keys, keys.Length);

                userNode.SetValue<NSDictionary>(data);

                //txtDescripcionM.Text = "";
                //txtDatoM.Text = "";

                UIAlertView _error = new UIAlertView("Correcto", "Dia Eliminado", null, "Ok", null);

                _error.Show();
            this.NavigationController.PopViewController(true);
        }


        #region Imagen

        void BtnImageM_TouchUpInside(object sender, EventArgs e)
        {
            ShowOptions();
        }


        void ShowOptions()
        {
            var alert = UIAlertController.Create(null, null, UIAlertControllerStyle.ActionSheet);

            alert.AddAction(UIAlertAction.Create("Abrir galeria", UIAlertActionStyle.Default, action => TryOpenLibrary()));
            alert.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel, null));

            PresentViewController(alert, animated: true, completionHandler: null);
        }

        void TryOpenLibrary()
        {
            CheckPhotoLibraryAutorizationStatus(PHPhotoLibrary.AuthorizationStatus);
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

        void ShowMessage(string title, string message, UIViewController fromViewController)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            fromViewController.PresentViewController(alert, true, null);
        }

        [Export("imagePickerController:didFinishPickingMediaWithInfo:")]
        public void FinishedPickingMedia(UIImagePickerController picker, Foundation.NSDictionary info)
        {
            var image = info[UIImagePickerController.OriginalImage] as UIImage;


            imgAdjuntoM.Image = image;

            //Encoding
            string encodedString = imgAdjuntoM.Image.AsJPEG(0.23f).GetBase64EncodedString(NSDataBase64EncodingOptions.None);
            foto = encodedString;

            //Descoding
            //byte[] encodedDataAsBytes = System.Convert.FromBase64String (foto);  
            //NSData ImageData = NSData.FromArray(encodedDataAsBytes);  
            //var img = UIImage.LoadFromData(ImageData);  
            //imgAdjunto.Image = img;  
            picker.DismissViewController(true, null);
        }



        [ExportAttribute("imagePickerControllerDidCancel:")]
        public void Canceled(UIImagePickerController picker)
        {
            picker.DismissViewController(true, null);
        }


        #endregion



	}
}
