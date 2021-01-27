using System;
using System.Collections.Generic;
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
using ProcessSA.BLL;

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorPerfil
{
    /// <summary>
    /// Lógica de interacción para AgregarPerfil.xaml
    /// </summary>
    public partial class AgregarPerfil : UserControl
    {
        public AgregarPerfil()
        {
            InitializeComponent();
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtNombrePerfil.Text = string.Empty;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            Perfil_BLC perfil = new Perfil_BLC();
            string _nombre = txtNombrePerfil.Text;

            try
            {
                if (_nombre != string.Empty)
                {
                    perfil.InsertarPerfil(_nombre);
                    MessageBox.Show("Perfil ingresado con éxito", "Registro de perfiles", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarCampos();
                }
                else 
                {
                    MessageBox.Show("Debe ingresar un nombre de perfil para continuar", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No puede registrar un nombre repetido de perfil.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }
    }
}
