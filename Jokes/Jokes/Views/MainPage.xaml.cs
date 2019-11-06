using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace Jokes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtJokeId = -1;
            jokeList.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void JokeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem != null)
            //{
            //    await Navigation.PushAsync(new MainPage { BindingContext = e.SelectedItem as Models.Joke });

            //}
        }

        async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MainPage
            //{
            //    BindingContext = new Models.Joke()
            //});
            Models.Joke jokes = new Models.Joke();
            jokes.aJoke = txtJoke.Text;
            await App.Database.SaveItemAsync(jokes);
            var vRefresh = new MainPage();
            Navigation.InsertPageBefore(vRefresh, this);

            Navigation.PopAsync();
        }
    }
}
