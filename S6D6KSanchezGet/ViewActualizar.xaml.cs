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
    public partial class ViewActualizar : ContentPage
    {

        public ViewActualizar(int codigoSeleccionado, String nombreSeleccionado, String apellidoSeleccionado, int edadSeleccionado)
        {
            InitializeComponent();

            //Se carga los datos para mostrar

            lblCodigoActualizar.Text = codigoSeleccionado.ToString();
            txtNombreActualizar.Text = nombreSeleccionado.ToString();
            txtApellidoActualizar.Text = apellidoSeleccionado.ToString();
            txtEdadActualizar.Text = edadSeleccionado.ToString();

        }

        public void regresar()
        {
            Navigation.PushAsync(new MainPage());
        }


        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //por donde se van a ir los datos
                WebClient cliente = new WebClient();

                //variable
                var parametos = new System.Collections.Specialized.NameValueCollection();

                cliente.UploadValues("http://192.168.1.3/moviles/post.php?codigo=" + Int32.Parse(lblCodigoActualizar.Text) + "&" + "nombre=" + txtNombreActualizar.Text + "&" + "apellido=" + txtApellidoActualizar.Text + "&" + "edad=" + Int32.Parse(txtEdadActualizar.Text), "PUT", parametos);
                await DisplayAlert("Mensaje:", "Actualización correcta", "ok");
                regresar();


            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje", ex.Message, "ok");
            }
        }

        private async void btnRegresaInicio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

    }
}