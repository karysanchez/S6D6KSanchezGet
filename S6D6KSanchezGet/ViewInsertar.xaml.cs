using System;

using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S6D6KSanchezGet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewInsertar : ContentPage
    {
        public ViewInsertar()
        {
            InitializeComponent();
        }
        
      
        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            try
            {
                //por donde se van a ir los datos
                WebClient cliente = new WebClient();

                //variable
                var parametos = new System.Collections.Specialized.NameValueCollection();

                parametos.Add("codigo", txtCodigo.Text);
                parametos.Add("nombre", txtNombre.Text);
                parametos.Add("apellido", txtApellido.Text);
                parametos.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://192.168.1.3/moviles/post.php", "POST", parametos);
                await DisplayAlert("Mensaje:", "Ingreso correcto", "ok");
                regresar();


            }
            catch (Exception ex)
            {
                 await DisplayAlert("Mensaje", "ERROR: " + ex.Message, "ok");
            }
        }

        private async void btnRegresarPrincipal_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new MainPage());
        }

        public async void regresar()
        {
            await Navigation.PushAsync(new MainPage());
        }

    }
}