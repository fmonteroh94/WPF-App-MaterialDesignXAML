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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa
{
    /// <summary>
    /// Lógica de interacción para ViewEmpresa.xaml
    /// </summary>
    public partial class VistaEmpresa : UserControl
    {
        public VistaEmpresa()
        {
            InitializeComponent();
            LlenarDataGrid();
        }

        public void LlenarDataGrid()
        {
            dtgLista.DataContext = null;
            Empresa_BLC empresa = new Empresa_BLC();
            DataTable dt = empresa.ListarEmpresas();
            dtgLista.DataContext = dt;

            ICollectionView ordenarLista = CollectionViewSource.GetDefaultView(dtgLista.DataContext);
            if (ordenarLista != null && ordenarLista.CanSort == true)
            {
                ordenarLista.SortDescriptions.Clear();
                ordenarLista.SortDescriptions.Add(new SortDescription("IDEMPRESA", ListSortDirection.Ascending));
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgLista.SelectedItem;
            Empresa_BLC empresa = new Empresa_BLC();
            string codigo = (dtgLista.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
            empresa.EliminarEmpresa(int.Parse(codigo));
            LlenarDataGrid();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgLista.SelectedItem;
            Empresa_BLC empresa = new Empresa_BLC();
            string codigo = (dtgLista.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
            string rut = (dtgLista.SelectedCells[1].Column.GetCellContent(_item) as TextBlock).Text;
            string dv = (dtgLista.SelectedCells[2].Column.GetCellContent(_item) as TextBlock).Text;
            string nombre = (dtgLista.SelectedCells[3].Column.GetCellContent(_item) as TextBlock).Text;
            string razon = (dtgLista.SelectedCells[4].Column.GetCellContent(_item) as TextBlock).Text;
            string direccion = (dtgLista.SelectedCells[5].Column.GetCellContent(_item) as TextBlock).Text;
            string email = (dtgLista.SelectedCells[6].Column.GetCellContent(_item) as TextBlock).Text;
            EditarEmpresa ee = new EditarEmpresa(codigo, rut, dv, nombre, razon, direccion, email);
            ee.Show();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarDataGrid();
        }
    }
}
