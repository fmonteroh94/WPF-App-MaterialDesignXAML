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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorDepartamento
{
    /// <summary>
    /// Lógica de interacción para EditarDepartamento.xaml
    /// </summary>
    public partial class EditarDepartamento : Window
    {
        public EditarDepartamento(string _id, string _nom)
        {
            InitializeComponent();
            txtCodigoDepartamento.Text = _id;
            txtNombreDepartamento.Text = _nom;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreDepartamento.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    Departamento_BLC departamento = new Departamento_BLC();
                    int _codigo = int.Parse(txtCodigoDepartamento.Text);
                    string _nombre = txtNombreDepartamento.Text;
                    departamento.ActualizarDepartamento(_codigo, _nombre);
                    MessageBox.Show("Departamento editado con éxito", "Editar departamento", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al intentar editar el departamento seleccionado. Por favor verifique que los campos ingresados son válidos e inténtelo nuevamente. Si el problema persiste, contacte con su administrador de sistemas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
