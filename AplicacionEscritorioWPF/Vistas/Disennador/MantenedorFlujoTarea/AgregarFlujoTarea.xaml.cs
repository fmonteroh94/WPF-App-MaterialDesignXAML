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

namespace AplicacionEscritorioWPF.Vistas.Disennador.MantenedorFlujoTarea
{
    /// <summary>
    /// Lógica de interacción para AgregarFlujoTarea.xaml
    /// </summary>
    public partial class AgregarFlujoTarea : UserControl
    {
        public AgregarFlujoTarea()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtFlujoTarea.Text != string.Empty && dtpFecha.SelectedDate != null)
                {
                    FlujoTarea_BLC flujo = new FlujoTarea_BLC();
                    string _nombre = txtFlujoTarea.Text;
                    DateTime _fecha = dtpFecha.SelectedDate.Value;
                    flujo.InsertarFlujo(_nombre, _fecha);
                    MessageBox.Show("Flujo de tarea ingresado con éxito.", "Registro de flujos de tarea", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre y fecha válidos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error al intentar ingresar un nuevo flujo. Por favor verifique que los valores ingresados estén correcto, si el problema persiste contacto con su administrador de sistema.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void limpiarCampos()
        {
            txtFlujoTarea.Text = string.Empty;
            dtpFecha.SelectedDate = null;
        }
    }
}
