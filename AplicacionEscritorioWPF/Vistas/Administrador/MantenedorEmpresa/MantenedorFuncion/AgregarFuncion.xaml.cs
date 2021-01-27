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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorFuncion
{
    /// <summary>
    /// Lógica de interacción para AgregarFuncion.xaml
    /// </summary>
    public partial class AgregarFuncion : UserControl
    {
        public AgregarFuncion()
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
            cbxEmpresa.SelectedValue = null;
        }

        private void cbxArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxArea.SelectedValue == null)
            {
                if (cbxEmpresa.SelectedValue != null)
                {
                    cbxArea.DataContext = null;
                    Area_BLC areas = new Area_BLC();
                    DataTable dtan = areas.ListarAreas(int.Parse(cbxEmpresa.SelectedValue.ToString()));
                    cbxArea.ItemsSource = dtan.DefaultView;
                    cbxArea.DisplayMemberPath = "NOMBRE";
                    cbxArea.SelectedValuePath = "IDAREA";
                }
                else 
                {
                    cbxArea.DataContext = null;
                    cbxArea.SelectedValue = null;
                }

            }
            else 
            {
                cbxDepartamento.DataContext = null;
                Departamento_BLC deptos = new Departamento_BLC();
                DataTable dta = deptos.ListarDepartamentos(int.Parse(cbxArea.SelectedValue.ToString()));
                cbxDepartamento.ItemsSource = dta.DefaultView;
                cbxDepartamento.DisplayMemberPath = "NOMBRE";
                cbxDepartamento.SelectedValuePath = "IDDEPARTAMENTO";
            }

        }

        private void cbxEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxEmpresa.SelectedValue == null)
            {
                cbxArea.SelectedValue = null;
                cbxDepartamento.SelectedValue = null;
            }
            else 
            {
                cbxDepartamento.DataContext = null;
                cbxDepartamento.SelectedValue = null;
                cbxArea.DataContext = null;
                Area_BLC areas = new Area_BLC();
                DataTable dta = areas.ListarAreas(int.Parse(cbxEmpresa.SelectedValue.ToString()));
                cbxArea.ItemsSource = dta.DefaultView;
                cbxArea.DisplayMemberPath = "NOMBRE";
                cbxArea.SelectedValuePath = "IDAREA";
            }

        }

        private void cbxDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxDepartamento.SelectedValue == null)
            {
                if (cbxArea.SelectedValue == null & cbxEmpresa != null)
                {
                    cbxArea.DataContext = null;
                    Area_BLC areas = new Area_BLC();
                    DataTable dtan = areas.ListarAreas(int.Parse(cbxEmpresa.SelectedValue.ToString()));
                    cbxArea.ItemsSource = dtan.DefaultView;
                    cbxArea.DisplayMemberPath = "NOMBRE";
                    cbxArea.SelectedValuePath = "IDAREA";
                }
                else if(cbxEmpresa.SelectedValue == null && cbxArea.SelectedValue == null)
                {
                    cbxDepartamento.SelectedValue = null;
                }
                else 
                {
                    cbxDepartamento.DataContext = null;
                    Departamento_BLC deptos = new Departamento_BLC();
                    DataTable dta = deptos.ListarDepartamentos(int.Parse(cbxArea.SelectedValue.ToString()));
                    cbxDepartamento.ItemsSource = dta.DefaultView;
                    cbxDepartamento.DisplayMemberPath = "NOMBRE";
                    cbxDepartamento.SelectedValuePath = "IDDEPARTAMENTO";
                }

            }
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (cbxEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una empresa", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (cbxArea.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un área", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (cbxDepartamento.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un departamento", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (txtNombreFuncion.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else 
            {
                try
                {
                    Funcion_BLC funcion = new Funcion_BLC();
                    string _nombre = txtNombreFuncion.Text;
                    int _departamento = int.Parse(cbxDepartamento.SelectedValue.ToString());
                    funcion.InsertarFuncion(_nombre, _departamento);
                    MessageBox.Show("Función ingresada con éxito", "Agregar función", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCampos();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al intentar registrar la función. Por favor verifique que los campos ingresados son válidos e inténtelo nuevamente. Si el problema persiste, contacte con su administrador de sistemas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombreFuncion.Text = string.Empty;
            cbxDepartamento.SelectedValue = null;
            cbxArea.SelectedValue = null;
            cbxDepartamento.SelectedValue = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarComboBox();
        }
    }
}
