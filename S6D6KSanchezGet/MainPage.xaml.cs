using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace S6D6KSanchezGet
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.3/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<S6D6KSanchezGet.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            Get();
        }

        public async void Get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<S6D6KSanchezGet.Ws.Datos> posts = JsonConvert.DeserializeObject<List<S6D6KSanchezGet.Ws.Datos>>(content);
                _post = new ObservableCollection<S6D6KSanchezGet.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR " + ex.Message, "OK");
            }
        }


        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewInsertar());
        }
    }
}
