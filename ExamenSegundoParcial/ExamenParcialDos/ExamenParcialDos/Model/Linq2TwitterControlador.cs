using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinqToTwitter;

namespace ExamenParcialDos.Model
{
    public class Linq2TwitterControlador
    {


        SingleUserAuthorizer autorizacion;
        TwitterContext twitterContext;

        public event EventHandler<GetTweetsEventArgs> GetTweets;
        public event EventHandler<GetTweetFailedEventArgs> ErrorGetTweets;

        static Lazy<Linq2TwitterControlador> lista = new Lazy<Linq2TwitterControlador>(() => new Linq2TwitterControlador());
        public static Linq2TwitterControlador SharedInstance { get => lista.Value; }


        Linq2TwitterControlador()
        {
            autorizacion = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = "iLt5oIEB5DOajHCNK1cB8X1P1",
                    ConsumerSecret = "hziIS1SmJeTkjI1GcLfunKnIzedbtiCORLBShKaPCzUlrVADW6",
                    AccessToken = "251716676-9is9A4GwXAHEBoDPjYMCC0vjo1Jd6zclfOCFoEeb",
                    AccessTokenSecret = "GHGZJsyRNwhKYUm1Y20X4iVtKLWaFw7cQlc88Zw0eXiWe"
                }
            };
            twitterContext = new TwitterContext(autorizacion);
        }


        public void BusquedaTweets(string query)
        {
            Task.Factory.StartNew(async () => {
                try
                {
                    var tweets = await BusquedaTweetsAsync(query);

                    var e = new GetTweetsEventArgs(tweets);

                    GetTweets?.Invoke(this, e);
                }
                catch (Exception ex)
                {
                    var e = new GetTweetFailedEventArgs(ex.Message);
                    ErrorGetTweets?.Invoke(this, e);
                }
            });

        }

        async Task<List<Status>> BusquedaTweetsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<Status>();
            }

            Search searchResponse = await
                (from search in twitterContext.Search
                 where search.Type == SearchType.Search &&
                 search.Query == query &&
                 search.TweetMode == TweetMode.Extended
                 select search)
                .SingleOrDefaultAsync();


            return searchResponse?.Statuses;


        }



    }

    public class GetTweetsEventArgs : EventArgs
    {
        public List<Status> Tweets { get; private set; }

        public GetTweetsEventArgs(List<Status> tweets)
        {
            Tweets = tweets;
        }

    }

    public class GetTweetFailedEventArgs : EventArgs
    {
        public string MensajeError { get; private set; }

        public GetTweetFailedEventArgs(string error)
        {
            MensajeError = error;
        }

    }
}
