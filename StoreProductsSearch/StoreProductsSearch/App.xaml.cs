using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreProductsSearch
{
    public partial class App : Application
    {
        static ProductItemDatabase database;
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            var nav = new NavigationPage(new ProductItemListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }
        public static ProductItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProductItemDatabase();
                }
                return database;
            }
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
