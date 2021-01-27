using ProcessSA.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica de interacción para ListarFunciones.xaml
    /// </summary>
    public partial class ListarFunciones : UserControl
    {
        public ListarFunciones()
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

        private void LlenarDataGrid()
        {
            if (cbxDepartamento.SelectedValue == null)
            {
                cbxDepartamento.DataContext = null;
                Departamento_BLC deptos = new Departamento_BLC();
                DataTable dtd = deptos.ListarDepartamentos(int.Parse(cbxArea.SelectedValue.ToString()));
                cbxDepartamento.ItemsSource = dtd.DefaultView;
                cbxDepartamento.DisplayMemberPath = "NOMBRE";
                cbxDepartamento.SelectedValuePath = "IDDEPARTAMENTO";
            }
            else
            {
                int _depto = int.Parse(cbxDepartamento.SelectedValue.ToString());
                dtgListaFunciones.DataContext = null;
                Funcion_BLC funciones = new Funcion_BLC();
                DataTable dtf = funciones.ListarFunciones(_depto);
                dtgListaFunciones.DataContext = dtf;

                ICollectionView ordenarLista = CollectionViewSource.GetDefaultView(dtgListaFunciones.DataContext);
                if (ordenarLista != null && ordenarLista.CanSort == true)
                {
                    ordenarLista.SortDescriptions.Clear();
                    ordenarLista.SortDescriptions.Add(new SortDescription("IDFUNCION", ListSortDirection.Ascending));
                }
            }

        }

        private void cbxDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LlenarDataGrid();
            dtgListaFunciones.Visibility = Visibility.Visible;
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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgListaFunciones.SelectedItem;
            string codigo = (dtgListaFunciones.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
            string nombre = (dtgListaFunciones.SelectedCells[1].Column.GetCellContent(_item) as TextBlock).Text;
            EditarFuncion ef = new EditarFuncion(codigo, nombre);
            ef.Show();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object _item = dtgListaFunciones.SelectedItem;
                Funcion_BLC funciones = new Funcion_BLC();
                string codigo = (dtgListaFunciones.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;

                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar la función seleccionada?", "Confirmación de eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    funciones.EliminarFuncion(int.Parse(codigo));
                    LlenarDataGrid();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error al intentar eliminar la función seleccionada. Si el problema persiste, contacte con su administrador de sistema.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            LlenarDataGrid();
        }
    }
}
