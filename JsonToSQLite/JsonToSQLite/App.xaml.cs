using JsonToSQLite.Models.SQLiteSettings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JsonToSQLite
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        static PostDatabase database;
        public static PostDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PostDatabase();
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
