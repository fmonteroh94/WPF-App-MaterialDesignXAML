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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorFuncion
{
    /// <summary>
    /// Lógica de interacción para EditarFuncion.xaml
    /// </summary>
    public partial class EditarFuncion : Window
    {
        public EditarFuncion(string _codigo, string _nombre)
        {
            InitializeComponent();
            txtCodigoFuncion.Text = _codigo;
            txtNombreFuncion.Text = _nombre;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreFuncion.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    Funcion_BLC funcion = new Funcion_BLC();
                    int _codigo = int.Parse(txtCodigoFuncion.Text);
                    string _nombre = txtNombreFuncion.Text;
                    funcion.ActualizarFuncion(_codigo, _nombre);
                    MessageBox.Show("Funcioón editada con éxito", "Editar función", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al intentar editar la función seleccionada. Por favor verifique que los campos ingresados son válidos e inténtelo nuevamente. Si el problema persiste, contacte con su administrador de sistemas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
