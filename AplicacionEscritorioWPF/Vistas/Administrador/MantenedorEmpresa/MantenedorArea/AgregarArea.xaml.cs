using ProcessSA.BLL;
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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorArea
{
    /// <summary>
    /// Lógica de interacción para AgregarArea.xaml
    /// </summary>
    public partial class AgregarArea : UserControl
    {
        public AgregarArea()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            cbxEmpresa.DataContext = null;
            Empresa_BLC empresas = new Empresa_BLC();
            DataTable dte = empresas.ListarEmpresas();
            cbxEmpresa.ItemsSource = dte.DefaultView;
            cbxEmpresa.DisplayMemberPath = "NOMBRE";
            cbxEmpresa.SelectedValuePath = "IDEMPRESA";
        }

        private void LimpiarCampos() 
        {
            txtNombreArea.Text = string.Empty;
            cbxEmpresa.SelectedValue = null;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (cbxEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una empresa","¡Advertencia!",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            if (txtNombreArea.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else 
            {
                try
                {
                    Area_BLC area = new Area_BLC();
                    string _nombre = txtNombreArea.Text;
                    int _empresa = int.Parse(cbxEmpresa.SelectedValue.ToString());
                    area.InsertarArea(_nombre, _empresa);
                    MessageBox.Show("Área registrada con éxito", "Registrar Área", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCampos();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al intentar registrar el área. Por favor verifique que los campos ingresados son válidos e inténtelo nuevamente. Si el problema persiste, contacte con su administrador de sistemas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarComboBox();
        }
    }
}
