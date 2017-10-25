using Tweetinvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TwitterApiApp.Models
{
    public class Credentials
    {
        public static string CONSUMER_KEY = ConfigurationManager.AppSettings["twitterConsumerKey"];
        public static string CONSUMER_SECRET = ConfigurationManager.AppSettings["twitterConsumerSecret"];
        public static string ACCESS_TOKEN = ConfigurationManager.AppSettings["twitterAccessToken"];
        public static string ACCESS_TOKEN_SECRET = ConfigurationManager.AppSettings["twitterAccessTokenSecret"];

        public static ITwitterCredentials GenerateCredentials()
        {
            return new TwitterCredentials(CONSUMER_KEY, CONSUMER_SECRET, ACCESS_TOKEN, ACCESS_TOKEN_SECRET);
        }
    }
}