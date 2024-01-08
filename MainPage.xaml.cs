using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace TrabajoFinalTeorema
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Agregar una URL de ejemplo al WebView
            webView.Source = "https://cadenatechsolutions.blogspot.com";
        }

        private async void OnIrAFacebookClicked(object sender, EventArgs e)
        {
            await AbrirNavegador("https://facebook.com/CadenaTechSolutions");
        }

        private async void OnIrAInstagramClicked(object sender, EventArgs e)
        {
            await AbrirNavegador("https://www.instagram.com/cadenatechsoluciones");
        }

        private async void OnIrAPaginaWebClicked(object sender, EventArgs e)
        {
            await AbrirNavegador("https://cadenatechsolutions.blogspot.com");
        }

        private async Task AbrirNavegador(string url)
        {
            await Task.Run(() =>
            {
                Device.InvokeOnMainThreadAsync(() =>
                {
                    Launcher.OpenAsync(new Uri(url));
                });
            });
        }

        private async void OnIniciarSesionClicked(object sender, EventArgs e)
        {
            string correo = correoEntry.Text;
            string contrasena = contrasenaEntry.Text;

            // Validar el login (sin conexión a base de datos)
            bool loginExitoso = await ValidarLoginAsync(correo, contrasena);

            if (loginExitoso)
            {
                // Navegar a la siguiente página o realizar acciones adicionales
            }
            else
            {
                // Mostrar mensaje de error
                await DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
        }

        private async Task<bool> ValidarLoginAsync(string correo, string contrasena)
        {
            // Aquí puedes realizar la lógica de validación sin conectar a la base de datos
            // Por ejemplo, podrías comparar con credenciales predefinidas o utilizar otro método de autenticación
            // Esto es solo un ejemplo simplificado
            return correo == "usuario" && contrasena == "contrasena";
        }

        private async void OnRegistrarseClicked(object sender, EventArgs e)
        {
            string nuevoCorreo = nuevoCorreoEntry.Text;
            string nuevaContrasena = nuevaContrasenaEntry.Text;
            string confirmarContrasena = confirmarContrasenaEntry.Text;

            // Validar el registro (sin conexión a base de datos)
            bool registroExitoso = await ValidarRegistroAsync(nuevoCorreo, nuevaContrasena, confirmarContrasena);

            if (registroExitoso)
            {
                // Navegar a la siguiente página o realizar acciones adicionales
            }
            else
            {
                // Mostrar mensaje de error
                await DisplayAlert("Error", "Registro fallido. Verifica tus datos.", "OK");
            }
        }

        private async Task<bool> ValidarRegistroAsync(string nuevoCorreo, string nuevaContrasena, string confirmarContrasena)
        {
            // Aquí puedes realizar la lógica de validación sin conectar a la base de datos
            // Por ejemplo, podrías verificar que las contraseñas coincidan
            // Esto es solo un ejemplo simplificado
            return nuevaContrasena == confirmarContrasena;
        }
    }
}



