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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorArea
{
    /// <summary>
    /// Lógica de interacción para EditarArea.xaml
    /// </summary>
    public partial class EditarArea : Window
    {
        public EditarArea(string _codigo, string _nombre)
        {
            InitializeComponent();
            txtNombreArea.Text = _nombre;
            txtCodigoArea.Text = _codigo;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreArea.Text == null)
            {
                MessageBox.Show("Debe ingresar un nombre","¡Advertencia!",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    Area_BLC area = new Area_BLC();
                    area.ActualizarArea(int.Parse(txtCodigoArea.Text), txtNombreArea.Text);
                    MessageBox.Show("Área editada con éxito", "Editar área", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Se produjo un error al intentar editar el área seleccionada. Por favor compruebe que los campos ingresados son correctos, si el problema persiste contacte con su administrador de sistema.", "¡Eror!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
