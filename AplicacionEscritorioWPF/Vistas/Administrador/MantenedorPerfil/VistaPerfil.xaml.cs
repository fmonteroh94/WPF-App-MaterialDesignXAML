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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProcessSA.BLL;
using System.Data;
using System.ComponentModel;
using AplicacionEscritorioWPF.Vistas.Administrador.MantenedorPerfil;
using System.Windows.Threading;

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorPerfil
{
    /// <summary>
    /// Lógica de interacción para VistaPerfil.xaml
    /// </summary>
    
    public partial class VistaPerfil : UserControl
    {
        public VistaPerfil()
        {
            InitializeComponent();
        }

        public void LlenarDataGrid() 
        {
            dtgLista.DataContext = null;
            Perfil_BLC perfil = new Perfil_BLC();
            DataTable dt = perfil.ListarPerfiles();
            dtgLista.DataContext = dt;

            ICollectionView ordenarLista = CollectionViewSource.GetDefaultView(dtgLista.DataContext);
            if (ordenarLista != null && ordenarLista.CanSort == true)
            {
                ordenarLista.SortDescriptions.Clear();
                ordenarLista.SortDescriptions.Add(new SortDescription("IDPERFIL", ListSortDirection.Ascending));
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object _item = dtgLista.SelectedItem;
                Perfil_BLC perfil = new Perfil_BLC();
                string codigo = (dtgLista.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;

                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el perfil seleccionado?", "Confirmación de eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    perfil.EliminarPerfil(int.Parse(codigo));
                    LlenarDataGrid();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No puede eliminar un perfil que tenga usuarios asociados a él.","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgLista.SelectedItem;
            string codigo = (dtgLista.SelectedCells[0].Column.GetCellContent(_item) as TextBlock).Text;
            string nombre = (dtgLista.SelectedCells[1].Column.GetCellContent(_item) as TextBlock).Text;
            EditarPerfil ep = new EditarPerfil(codigo, nombre);
            ep.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarDataGrid();
        }
    }
}
