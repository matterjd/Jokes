using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Diagnostics;

namespace Jokes
{
    public partial class App : Application
    {
        static Jokes.Data.JokeDatabase database;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static Jokes.Data.JokeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new Jokes.Data.JokeDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JokeSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtJokeId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        
    }

    
   
    
}
