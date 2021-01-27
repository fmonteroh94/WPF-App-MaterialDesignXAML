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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorArea
{
    /// <summary>
    /// Lógica de interacción para ListarAreas.xaml
    /// </summary>
    public partial class ListarAreas : UserControl
    {
        public ListarAreas()
        {
            InitializeComponent();
            LlenarComboBox();
            dtgListaAreas.Visibility = Visibility.Hidden;
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
            int _empresa = int.Parse(cbxEmpresa.SelectedValue.ToString());
            dtgListaAreas.DataContext = null;
            Area_BLC areas = new Area_BLC();
            DataTable dt = areas.ListarAreas(_empresa);
            dtgListaAreas.DataContext = dt;

            ICollectionView ordenarLista = CollectionViewSource.GetDefaultView(dtgListaAreas.DataContext);
            if (ordenarLista != null && ordenarLista.CanSort == true)
            {
                ordenarLista.SortDescriptions.Clear();
                ordenarLista.SortDescriptions.Add(new SortDescription("IDAREA", ListSortDirection.Ascending));
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgListaAreas.SelectedItem;
            string codigo = (dtgListaAreas.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
            string nombre = (dtgListaAreas.SelectedCells[1].Column.GetCellContent(_item) as TextBlock).Text;
            EditarArea ea = new EditarArea(codigo, nombre);
            ea.Show();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object _item = dtgListaAreas.SelectedItem;
                Area_BLC area = new Area_BLC();
                string codigo = (dtgListaAreas.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
                area.EliminarArea(int.Parse(codigo));
                LlenarDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("No puede eliminar un área que tenga departamentos asignados a ella. Sugerencia: Elimine todos los departamentos asociados al área seleccionada para proceder a la eliminación.");
            }
        }

        private void cbxEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LlenarDataGrid();
            dtgListaAreas.Visibility = Visibility.Visible;
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
