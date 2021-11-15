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

        S6D6KSanchezGet.Ws.Datos data;
        Boolean mostrar = false;

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

                //Captura valor seleccionado
                MyListView.ItemSelected += (sender, e) =>
                {
                    if (e.SelectedItem != null)
                    {
                        data = e.SelectedItem as S6D6KSanchezGet.Ws.Datos;
                        mostrar = true;
                        
                    }
                };
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "ERROR " + ex.Message, "OK");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (mostrar == true)
            {
                await Navigation.PushAsync(new ViewEliminar(data.codigo, data.nombre, data.apellido, data.edad));
                
            }
            else { await DisplayAlert("Error", "Seleccionar un registro ", "OK"); }
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ViewInsertar());
        }

        private async void btnPut_Clicked(object sender, EventArgs e)
        {
            if (mostrar == true)
            {
                await Navigation.PushAsync(new ViewActualizar(data.codigo, data.nombre, data.apellido, data.edad));
         
            }
            else
            {
                await DisplayAlert("Error", "Seleccionar un registro ", "OK");
            }
        }
    }
}
