using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using Newtonsoft.Json;
using App02_LoginSocial.Droid;
using App02_LoginSocial;

[assembly:ExportRenderer(typeof(LoginFacebook), typeof(LoginFacebookRenderer))]
namespace App02_LoginSocial.Droid
{
    public class LoginFacebookRenderer :PageRenderer
    {
        public LoginFacebookRenderer(Context context) : base(context)
        {
            var auth = new OAuth2Authenticator(
                                                "588821751564005", 
                                                "email", 
                                                new Uri("https://m.facebook.com/dialog/oauth/"), 
                                                new Uri("https://www.facebook.com/connect/login_success.html")
                                              );

            auth.Completed += async(sender, args) => {
                if (args.IsAuthenticated)
                {
                    var token = args.Account.Properties["access_token"].ToString();

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=name,email"), null, args.Account);
                    var resposta = await request.GetResponseAsync();

                    dynamic retorno = JsonConvert.DeserializeObject<dynamic>(resposta.GetResponseText());

                    string nome = retorno.name.toString();
                    string email = retorno.email.toString();
                }
            }
            ;
            Activity activity = Context as Activity;

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}