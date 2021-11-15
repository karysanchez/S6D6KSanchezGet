using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S6D6KSanchezGet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewEliminar : ContentPage
    {
        public ViewEliminar(int codigoSeleccionado, String nombreSeleccionado, String apellidoSeleccionado, int edadSeleccionado)
        {
            InitializeComponent();
            //Se carga los datos para mostrar

            lblCodigo.Text = codigoSeleccionado.ToString();
            lblNombre.Text = nombreSeleccionado.ToString();
            lblApellido.Text = apellidoSeleccionado.ToString();
            lblEdad.Text = edadSeleccionado.ToString();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //por donde se van a ir los datos
                WebClient cliente = new WebClient();

                //variable
                var parametos = new System.Collections.Specialized.NameValueCollection();

                cliente.UploadValues("http://192.168.1.3/moviles/post.php?codigo=" + Int32.Parse(lblCodigo.Text), "DELETE", parametos);
                await DisplayAlert("Mensaje:", "Eliminación correcta", "ok");
                regresar();


            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje", ex.Message, "ok");
            }
        }
        public void regresar()
        {
            Navigation.PushAsync(new MainPage());
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}