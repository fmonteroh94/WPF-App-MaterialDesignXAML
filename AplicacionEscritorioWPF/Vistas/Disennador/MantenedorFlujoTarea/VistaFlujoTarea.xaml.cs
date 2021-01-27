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

namespace AplicacionEscritorioWPF.Vistas.Disennador.MantenedorFlujoTarea
{
    /// <summary>
    /// Lógica de interacción para VistaFlujoTarea.xaml
    /// </summary>
    public partial class VistaFlujoTarea : UserControl
    {
        public VistaFlujoTarea()
        {
            InitializeComponent();
        }

        private void LlenarDataGrid()
        {
            dtgLista.DataContext = null;
            FlujoTarea_BLC flujo = new FlujoTarea_BLC();
            DataTable dt = flujo.ListarFlujos();
            dtgLista.DataContext = dt;

            ICollectionView ordenarLista = CollectionViewSource.GetDefaultView(dtgLista.DataContext);
            if (ordenarLista != null && ordenarLista.CanSort == true)
            {
                ordenarLista.SortDescriptions.Clear();
                ordenarLista.SortDescriptions.Add(new SortDescription("IDFLUJOTAREA", ListSortDirection.Ascending));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarDataGrid();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgLista.SelectedItem;
            FlujoTarea_BLC flujo = new FlujoTarea_BLC();
            string codigo = (dtgLista.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;

            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el flujo seleccionado?", "Confirmación de eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                flujo.EliminarFlujo(int.Parse(codigo));
                LlenarDataGrid();
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgLista.SelectedItem;
            string codigo = (dtgLista.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
            string nombre = (dtgLista.SelectedCells[1].Column.GetCellContent(_item) as TextBlock).Text;
            string fecha = (dtgLista.SelectedCells[2].Column.GetCellContent(_item) as TextBlock).Text;
            EditarFlujoTarea ef = new EditarFlujoTarea(codigo, nombre, fecha);
            ef.Show();
        }
    }
}
