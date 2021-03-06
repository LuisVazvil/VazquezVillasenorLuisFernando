// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using ExamenParcialDos.Model;
using Foundation;
using UIKit;
using LinqToTwitter;

namespace ExamenParcialDos
{
    public partial class TableViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate, IUISearchResultsUpdating
	{

        #region clas variebles

        UISearchController BarraBusqueda;
        List<Status> TodosTweets;

        #endregion

		public TableViewController (IntPtr handle) : base (handle)
		{
		}


        #region Controller Life 
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitialComponent();
        }

        #endregion



        #region User Interactions

        partial void btn_Icons(NSObject sender)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl("https://icons8.com"));
        }

		partial void btn_pajaro(NSObject sender)
		{
            var alert = UIAlertController.Create("Hola", "Bienvenido", UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
		}

		#endregion



		#region Internal Functional
		void InitialComponent()
        {

            TodosTweets = new List<Status>();

            Linq2TwitterControlador.SharedInstance.GetTweets += TraerTweets_GetTweets;
            Linq2TwitterControlador.SharedInstance.ErrorGetTweets += TraerTweets_GetTweetFailed;

            BarraBusqueda = new UISearchController(searchResultsController: null)
            {
                SearchResultsUpdater = this,
                DimsBackgroundDuringPresentation = false
            };

            tblView.RowHeight = UITableView.AutomaticDimension;
            tblView.DataSource = this;
            tblView.Delegate = this;
            tblView.TableHeaderView = BarraBusqueda.SearchBar;



        }
        public void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            Linq2TwitterControlador.SharedInstance.BusquedaTweets(searchController.SearchBar.Text);
        }

        void TraerTweets_GetTweets(object sender, GetTweetsEventArgs e)
        {
            TodosTweets = e.Tweets;
            InvokeOnMainThread(() => tblView.ReloadData());
        }

        void TraerTweets_GetTweetFailed(object sender, GetTweetFailedEventArgs e)
        {
            var alert = UIAlertController.Create("Error", "No se puedo traer ls tweets", UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            this.PresentViewController(alert, true, null);
        }


		[Export("numberOfSectionsInTableView:")]
        public nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }


        public nint RowsInSection(UITableView tableView, nint section)
        {
            return TodosTweets.Count;
        }




        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var tweetEspecifico = TodosTweets[indexPath.Row];
            var celda = tableView.DequeueReusableCell("TweetsCell", indexPath) as TweetsCell;
            if(tweetEspecifico.FavoriteCount.ToString() == null)
            {
                celda.NumeroMeGusta = "0";
            }
            else
            {
                celda.NumeroMeGusta = tweetEspecifico.FavoriteCount?.ToString();
            }
            celda.Tweet = tweetEspecifico.FullText;

            return celda;
            throw new NotImplementedException();

        }



        #endregion
	}
}
