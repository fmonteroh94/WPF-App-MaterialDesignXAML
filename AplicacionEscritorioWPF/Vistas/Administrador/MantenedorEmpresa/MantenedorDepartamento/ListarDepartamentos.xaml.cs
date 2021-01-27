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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorDepartamento
{
    /// <summary>
    /// Lógica de interacción para ListarDepartamentos.xaml
    /// </summary>
    public partial class ListarDepartamentos : UserControl
    {
        public ListarDepartamentos()
        {
            InitializeComponent();
            LlenarComboBox();
            dtgListaDeptos.Visibility = Visibility.Hidden;
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

        private void LlenarDataGrid()
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
            else 
            {
                int _area = int.Parse(cbxArea.SelectedValue.ToString());
                dtgListaDeptos.DataContext = null;
                Departamento_BLC deptos = new Departamento_BLC();
                DataTable dt = deptos.ListarDepartamentos(_area);
                dtgListaDeptos.DataContext = dt;

                ICollectionView ordenarLista = CollectionViewSource.GetDefaultView(dtgListaDeptos.DataContext);
                if (ordenarLista != null && ordenarLista.CanSort == true)
                {
                    ordenarLista.SortDescriptions.Clear();
                    ordenarLista.SortDescriptions.Add(new SortDescription("IDDEPARTAMENTO", ListSortDirection.Ascending));
                }
            }

        }

        private void cbxArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LlenarDataGrid();
            dtgListaDeptos.Visibility = Visibility.Visible;
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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgListaDeptos.SelectedItem;
            string codigo = (dtgListaDeptos.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
            string nombre = (dtgListaDeptos.SelectedCells[1].Column.GetCellContent(_item) as TextBlock).Text;
            EditarDepartamento ed = new EditarDepartamento(codigo, nombre);
            ed.Show();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object _item = dtgListaDeptos.SelectedItem;
                Departamento_BLC departamento = new Departamento_BLC();
                string codigo = (dtgListaDeptos.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;

                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el departamento seleccionado?", "Confirmación de eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    departamento.EliminarDepartamento(int.Parse(codigo));
                    LlenarDataGrid();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error al intentar eliminar el departamento seleccionado. Si el problema persiste, contacte con su administrador de sistema.","¡Error!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //LlenarComboBox();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            LlenarDataGrid();
        }
    }
}
