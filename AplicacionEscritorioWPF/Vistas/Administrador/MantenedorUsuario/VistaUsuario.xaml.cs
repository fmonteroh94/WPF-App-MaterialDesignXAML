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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorUsuario
{
    /// <summary>
    /// Lógica de interacción para VistaUsuario.xaml
    /// </summary>
    public partial class VistaUsuario : UserControl
    {
        public VistaUsuario()
        {
            InitializeComponent();
            LlenarDataGrid();
        }

        public void LlenarDataGrid()
        {
            dtgLista.DataContext = null;
            Usuario_BLC usuario = new Usuario_BLC();
            DataTable dt = usuario.ListarUsuarios();
            dtgLista.DataContext = dt;
        
            ICollectionView ordenarLista = CollectionViewSource.GetDefaultView(dtgLista.DataContext);
            if (ordenarLista != null && ordenarLista.CanSort == true)
            {
                ordenarLista.SortDescriptions.Clear();
                ordenarLista.SortDescriptions.Add(new SortDescription("IDUSUARIO", ListSortDirection.Ascending));
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            object _item = dtgLista.SelectedItem;
            string codigo = ((DataRowView)dtgLista.SelectedItem).Row["IDUSUARIO"].ToString();
            string nombres = ((DataRowView)dtgLista.SelectedItem).Row["NOMBRES"].ToString();
            string paterno = ((DataRowView)dtgLista.SelectedItem).Row["APELLIDOPATERNO"].ToString();
            string materno = ((DataRowView)dtgLista.SelectedItem).Row["APELLIDOMATERNO"].ToString();
            string usuario = ((DataRowView)dtgLista.SelectedItem).Row["NOMBREUSUARIO"].ToString();
            string pass = ((DataRowView)dtgLista.SelectedItem).Row["CONTRASENNA"].ToString();
            string email = ((DataRowView)dtgLista.SelectedItem).Row["EMAIL"].ToString();
            string perfil = ((DataRowView)dtgLista.SelectedItem).Row["IDPERFIL"].ToString();
            string cargo = ((DataRowView)dtgLista.SelectedItem).Row["IDCARGO"].ToString();
            string empresa = ((DataRowView)dtgLista.SelectedItem).Row["IDEMPRESA"].ToString();
            EditarUsuario eu = new EditarUsuario(codigo,nombres,paterno,materno,usuario,pass,email,perfil,cargo,empresa);
            eu.Show();

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object _item = dtgLista.SelectedItem;
                Usuario_BLC usuario = new Usuario_BLC();
                string codigo = ((DataRowView)dtgLista.SelectedItem).Row["IDUSUARIO"].ToString();
                MessageBoxResult result = MessageBox.Show("¿Está seguro que desea eliminar el usuario seleccionado?", "Confirmación de eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    usuario.EliminarUsuario(int.Parse(codigo));
                    LlenarDataGrid();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarDataGrid();
        }
    }
}
