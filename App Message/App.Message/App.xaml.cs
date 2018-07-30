using System;
using Xamarin.Forms;
using App.Message.Views;
using Xamarin.Forms.Xaml;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App.Message
{
    public partial class App : Application
    {
        public static string Database => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "message.db3");

        public App()
        {
            InitializeComponent();

            Resources = new ResourceDictionary
            {
                { "primaryGreen", Color.FromHex("91CA47") },
                { "primaryDarkGreen", Color.FromHex("6FA22E") }
            };

            var nav = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"],
                BarTextColor = Color.White
            };

            MainPage = nav;
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }
        protected override void OnResume()
        {

        }
    }
}
