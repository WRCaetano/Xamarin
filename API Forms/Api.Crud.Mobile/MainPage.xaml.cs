using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Api.Crud.Mobile
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://5b5f1f808e9f160014b88db8.mockapi.io/api/product";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Post> _posts;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url);
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(content);
            _posts = new ObservableCollection<Post>(posts);
            MyListView.ItemsSource = _posts;
            base.OnAppearing();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            Post post = new Post
            {
                Title = $"Criado: {DateTime.UtcNow.Ticks}"
            };

            string content = JsonConvert.SerializeObject(post);
            await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));

            _posts.Insert(0, post);
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            Post post = _posts[0];
            post.Title = $"Atualizado: {DateTime.UtcNow.Ticks}";
            string content = JsonConvert.SerializeObject(post);
            await _client.PutAsync(Url + "/" + post.Id, new StringContent(content, Encoding.UTF8, "application/json"));
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            Post post = _posts[0];
            await _client.DeleteAsync(Url + "/" + post.Id);
            _posts.Remove(post);
        }
    }
}
