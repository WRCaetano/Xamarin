using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Message.Models;
using App.Message.ViewModels;

namespace App.Message.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageModel viewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainPageModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Item item)) return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage())
            {
                BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"],
                BarTextColor = Color.White
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}