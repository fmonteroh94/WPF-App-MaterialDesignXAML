using ProcessSA.BLL;
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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorCargo
{
    /// <summary>
    /// Lógica de interacción para AgregarCargo.xaml
    /// </summary>
    public partial class AgregarCargo : UserControl
    {
        public AgregarCargo()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            Cargo_BLC cargo = new Cargo_BLC();
            string _nombre = txtNombreCargo.Text;

            try
            {
                if (_nombre != string.Empty)
                {
                    cargo.InsertarCargo(_nombre);
                    MessageBox.Show("Cargo ingresado con éxito", "Registro de cargos", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre de cargo para continuar", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No puede registrar un nombre de cargo repetido.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
