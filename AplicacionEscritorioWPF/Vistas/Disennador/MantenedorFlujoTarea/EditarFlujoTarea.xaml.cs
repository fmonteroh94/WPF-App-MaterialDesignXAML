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

namespace AplicacionEscritorioWPF.Vistas.Disennador.MantenedorFlujoTarea
{
    /// <summary>
    /// Lógica de interacción para EditarFlujoTarea.xaml
    /// </summary>
    public partial class EditarFlujoTarea : Window
    {
        public EditarFlujoTarea(string _codigo, string _nombre, string _fecha)
        {
            InitializeComponent();
            txtCodigo.Text = _codigo;
            txtFlujoTarea.Text = _nombre;
            dtpFecha.SelectedDate = Convert.ToDateTime(_fecha);
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            FlujoTarea_BLC flujo = new FlujoTarea_BLC();
            try
            {
                if (txtFlujoTarea.Text != string.Empty && dtpFecha.SelectedDate != null)
                {
                    flujo.ActualizarFlujo(int.Parse(txtCodigo.Text), txtFlujoTarea.Text, dtpFecha.SelectedDate.Value);
                    MessageBox.Show("Flujo de tarea editado con éxito", "Editar Flujo de tarea", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error al intentar editar el flujo seleccionado. Por favor verifique que los valores ingresados estén correcto, si el problema persiste contacto con su administrador de sistema.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
