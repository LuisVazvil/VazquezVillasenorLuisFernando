using System;
using System.Collections.Generic;
using DiarioApp.Models;
using Foundation;
using UIKit;

namespace DiarioApp.Controllers
{
    public class TablaSource : UITableViewSource
    {
        List<Dia> diarios;

        public TablaSource(List<Dia> d)
        {
            this.diarios = d;
        }

        protected TablaSource(NSObjectFlag t) : base(t)
        {
        }

        #region UITableView Data source

        [Export("numberOfSectionsInTableView:")]
        public nint NumberOfSections(UITableView tableView)
        {
            return 1;
        } 


        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return diarios.Count;
        }




        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var c = diarios[indexPath.Row].Emocion;
            var diaU = diarios[indexPath.Row];
            var fec = diarios[indexPath.Row].Fecha;
            String[] splitstring = fec.Split('-');
            var cell = tableView.DequeueReusableCell(CellController.Key, indexPath) as CellController;
            cell.Titulo = diaU.Titulo;
            cell.Descripcion = diaU.Descripcion;
            cell.Dia = splitstring[0];
            var m = splitstring[1];

            //cell.Tweet = tweet.FullText;
            //cell.FavoritedCount = tweet.FavoriteCount?.ToString() ?? "0";
            //cell.RetweetedCount = tweet.RetweetCount.ToString();

            switch(m)
            {
                case "01":
                    cell.Mes = UIImage.FromBundle("enero");
                    break;
                case "02":
                    cell.Mes = UIImage.FromBundle("febrero");
                    break;
                case "03":
                    cell.Mes = UIImage.FromBundle("marzo");
                    break;
                case "04":
                    cell.Mes = UIImage.FromBundle("abril");
                    break;
                case "05":
                    cell.Mes = UIImage.FromBundle("mayo");
                    break;
                case "06":
                    cell.Mes = UIImage.FromBundle("junio");
                    break;
                case "07":
                    cell.Mes = UIImage.FromBundle("julio");
                    break;
                case "08":
                    cell.Mes = UIImage.FromBundle("agosto");
                    break;
                case "09":
                    cell.Mes = UIImage.FromBundle("septiembre");
                    break;
                case "10":
                    cell.Mes = UIImage.FromBundle("octubre");
                    break;
                case "11":
                    cell.Mes = UIImage.FromBundle("noviembre");
                    break;
                case "12":
                    cell.Mes = UIImage.FromBundle("diciembre");
                    break;
            }

            switch(c)
            {
                case "Emocionante" :
                    cell.BackgroundColor =  UIColor.FromRGB(46, 165, 157);
                    break;
                case "Divertido":
                    cell.BackgroundColor = UIColor.FromRGB(204, 102, 8);
                    break;
                case "Triste":
                    cell.BackgroundColor = UIColor.FromRGB(64, 96, 104);
                    break;
                case "Estresante":
                    cell.BackgroundColor = UIColor.FromRGB(165, 13, 13);
                    break;
                case "Alegre":
                    cell.BackgroundColor = UIColor.FromRGB(117, 181, 54);
                    break;
                case "Cansado":
                    cell.BackgroundColor = UIColor.FromRGB(96, 86, 47);
                    break;
                case "Indiferente":
                    cell.BackgroundColor = UIColor.FromRGB(122, 119, 119);
                    break;
            }

            return cell;
            throw new NotImplementedException();

        }


        #endregion

    }
}
