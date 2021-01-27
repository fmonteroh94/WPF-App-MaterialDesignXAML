using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AplicacionEscritorioWPF.Vistas.Administrador;
using AplicacionEscritorioWPF.Vistas.Disennador;
using AplicacionEscritorioWPF.VistaModelo;
using ProcessSA.BLL;

namespace AplicacionEscritorioWPF
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Usuario_BLC usuario = new Usuario_BLC();

            try
            {
                if (usuario.ValidarUsuario(txtUser.Text, Encriptacion.EncriptarSha256(txtPass.Password)) == 1)
                {
                    MessageBox.Show("Ingreso exitoso", "¡Felicidades!", MessageBoxButton.OK, MessageBoxImage.Information);
                    PanelControl panel = new PanelControl();
                    panel.Show();
                    this.Close();
                }
                else if (usuario.ValidarUsuario(txtUser.Text, Encriptacion.EncriptarSha256(txtPass.Password)) == 2)
                {
                    MessageBox.Show("Ingreso exitoso", "¡Felicidades!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Dashboard ds = new Dashboard();
                    ds.Show();
                    this.Close();
                }

            }
            catch (Exception)
            {
                if (txtUser.Text == string.Empty || txtPass.Password.Length <= 0)
                {
                    MessageBox.Show("Debe ingresar un nombre de usuario y contraseña", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("El nombre de usuario o contraseña son incorrectos", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

