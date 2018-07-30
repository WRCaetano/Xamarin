using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Message.Models;

namespace App.Message.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Titulo",
                Description = "Descrição"
            };

            BindingContext = this;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}