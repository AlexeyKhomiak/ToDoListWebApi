using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinClient
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.0.100:52950/api/ToDoListApi/";
        private readonly HttpClient _client = new HttpClient();
        public ObservableCollection<TodoList> _tasks;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url);
            List<TodoList> tasks = JsonConvert.DeserializeObject<List<TodoList>>(content);
            _tasks = new ObservableCollection<TodoList>(tasks);
            listViewTodoList.ItemsSource = _tasks;
            base.OnAppearing();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            TodoList post = new TodoList { TaskName = Title.Text, Notes = Description.Text, Done =false };
            
            string content = JsonConvert.SerializeObject(post); 
            await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
            _tasks.Insert(0, post);
        }
        
        private async void OnDelete(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            int index = _tasks.IndexOf((TodoList)e.Item);
            await _client.DeleteAsync(Url + "/" + index);
            _tasks.RemoveAt(index);
        }
    }
}
