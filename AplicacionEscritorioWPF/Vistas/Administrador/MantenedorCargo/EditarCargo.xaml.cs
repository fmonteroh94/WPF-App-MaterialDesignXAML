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
using System.Windows.Shapes;

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorCargo
{
    /// <summary>
    /// Lógica de interacción para EditarCargo.xaml
    /// </summary>
    public partial class EditarCargo : Window
    {
        public EditarCargo(string codigo, string nombre)
        {
            InitializeComponent();
            txtCodigoCargo.Text = codigo;
            txtNombreCargo.Text = nombre;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            Cargo_BLC cargo = new Cargo_BLC();
            try
            {
                if (txtNombreCargo.Text != string.Empty)
                {
                    cargo.ActualizarCargo(int.Parse(txtCodigoCargo.Text), txtNombreCargo.Text);
                    MessageBox.Show("Perfil editado con éxito", "Editar Perfil", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
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
