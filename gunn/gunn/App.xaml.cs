using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gunn
{
    public partial class App : Application
    {
        private const string FILE_NAME = "db.db";
        private static DboContext dB;
        public static DboContext DB
        {
            get
            {
                if (dB == null)
                {
                    string path = DependencyService.Get<IDBPath>().GetDBPath(FILE_NAME);
                    dB = new DboContext(path);
                    dB.Database.EnsureCreated();
                }
                return dB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
