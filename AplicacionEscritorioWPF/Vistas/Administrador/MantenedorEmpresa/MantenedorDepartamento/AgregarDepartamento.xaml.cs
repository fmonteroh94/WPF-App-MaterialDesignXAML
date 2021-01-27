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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorDepartamento
{
    /// <summary>
    /// Lógica de interacción para AgregarDepartamento.xaml
    /// </summary>
    public partial class AgregarDepartamento : UserControl
    {

        public AgregarDepartamento()
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

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (cbxEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una empresa", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (cbxArea.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un área", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (txtNombreDepartamento.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    Departamento_BLC departamento = new Departamento_BLC();
                    string _nombre = txtNombreDepartamento.Text;
                    int _area = int.Parse(cbxArea.SelectedValue.ToString());
                    departamento.InsertarDepartamento(_nombre, _area);
                    MessageBox.Show("Departamento ingresado con éxito", "Agregar departamento", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCampos();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al intentar registrar el departamento. Por favor verifique que los campos ingresados son válidos e inténtelo nuevamente. Si el problema persiste, contacte con su administrador de sistemas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombreDepartamento.Text = string.Empty;
        }

        private void cbxArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxArea.SelectedValue == null)
            {
                cbxArea.DataContext = null;
                Area_BLC areas = new Area_BLC();
                DataTable dta = areas.ListarAreas(int.Parse(cbxEmpresa.SelectedValue.ToString()));
                cbxArea.ItemsSource = dta.DefaultView;
                cbxArea.DisplayMemberPath = "NOMBRE";
                cbxArea.SelectedValuePath = "IDAREA";
            }

        }

        private void cbxEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxArea.DataContext = null;
            Area_BLC areas = new Area_BLC();
            DataTable dta = areas.ListarAreas(int.Parse(cbxEmpresa.SelectedValue.ToString()));
            cbxArea.ItemsSource = dta.DefaultView;
            cbxArea.DisplayMemberPath = "NOMBRE";
            cbxArea.SelectedValuePath = "IDAREA";

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //LlenarComboBox();
        }
    }
}
