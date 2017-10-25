using Tweetinvi;
using Tweetinvi.Models;
using TwitterApiApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweetinvi.Credentials.Models;

namespace TwitterApiApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TwitterAuth()
        {
            var appCreds = new ConsumerCredentials(Credentials.CONSUMER_KEY, Credentials.CONSUMER_SECRET);
            var redirectURL = "http://" + Request.Url.Authority + "/Home/ValidateTwitterAuth";
            var authenticationContext = AuthFlow.InitAuthentication(appCreds, redirectURL);

            return new RedirectResult(authenticationContext.AuthorizationURL);
        }

        public ActionResult ValidateTwitterAuth()
        {
            var token = new AuthenticationToken()
            {
                AuthorizationKey = Credentials.ACCESS_TOKEN,
                AuthorizationSecret = Credentials.ACCESS_TOKEN_SECRET,
                ConsumerCredentials = new ConsumerCredentials(Credentials.CONSUMER_KEY, Credentials.CONSUMER_SECRET)
            };

            // And then instead of passing the AuthenticationContext, just pass the AuthenticationToken
            var verifierCode = Request.Params.Get("oauth_verifier");

            if (verifierCode != null)
            {
                var userCreds = AuthFlow.CreateCredentialsFromVerifierCode(verifierCode, token);
                var user = Tweetinvi.User.GetAuthenticatedUser(userCreds);

                ViewBag.User = user;
            }

            return View();
        }
    }
}