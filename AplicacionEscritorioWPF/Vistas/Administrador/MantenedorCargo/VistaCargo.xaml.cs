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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorCargo
{
    /// <summary>
    /// Lógica de interacción para VistaCargo.xaml
    /// </summary>
    public partial class VistaCargo : UserControl
    {
        public VistaCargo()
        {
            InitializeComponent();
            LlenarDataGrid();
        }

        public void LlenarDataGrid()
        {
            dtgLista.DataContext = null;
            Cargo_BLC cargo = new Cargo_BLC();
            DataTable dt = cargo.ListarCargos();
            dtgLista.DataContext = dt;

            ICollectionView ordenarLista = CollectionViewSource.GetDefaultView(dtgLista.DataContext);
            if (ordenarLista != null && ordenarLista.CanSort == true)
            {
                ordenarLista.SortDescriptions.Clear();
                ordenarLista.SortDescriptions.Add(new SortDescription("IDCARGO", ListSortDirection.Ascending));
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object _item = dtgLista.SelectedItem;
                Cargo_BLC cargo = new Cargo_BLC();
                string codigo = (dtgLista.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
                string nombre = (dtgLista.SelectedCells[1].Column.GetCellContent(_item) as TextBlock).Text;
                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el cargo seleccionado?", "Confirmación de eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    cargo.EliminarCargo(int.Parse(codigo));
                    LlenarDataGrid();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No puede eliminar un cargo que tenga usuarios asignados a él.","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgLista.SelectedItem;
            string codigo = (dtgLista.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
            string nombre = (dtgLista.SelectedCells[1].Column.GetCellContent(_item) as TextBlock).Text;
            EditarCargo ec = new EditarCargo(codigo, nombre);
            ec.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarDataGrid();
        }
    }
}
