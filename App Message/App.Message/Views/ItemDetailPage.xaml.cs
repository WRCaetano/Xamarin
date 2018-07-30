using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Message.Models;
using App.Message.ViewModels;

namespace App.Message.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public async void Remove_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}