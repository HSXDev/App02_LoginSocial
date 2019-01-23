using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App02_LoginSocial
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoginFacebook.Clicked += Facebook;
        }

        public static void Facebook(object sender, EventArgs args)
        {
            App.Current.MainPage = new LoginFacebook();
        }
    }
}
