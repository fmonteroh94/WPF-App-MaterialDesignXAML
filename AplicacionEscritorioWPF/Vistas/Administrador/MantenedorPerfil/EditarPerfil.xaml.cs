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
using System.Windows.Shapes;

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorPerfil
{
    /// <summary>
    /// Lógica de interacción para EditarPerfil.xaml
    /// </summary>
    public partial class EditarPerfil : Window
    {
        public EditarPerfil(string codigo, string nombre)
        {
            InitializeComponent();
            txtNombrePerfil.Text = nombre;
            txtCodigoPerfil.Text = codigo;
        }

        private void limpiarCampos() 
        {
            txtNombrePerfil.Text = string.Empty;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            Perfil_BLC perfil = new Perfil_BLC();
            try
            {
                if (txtNombrePerfil.Text != string.Empty)
                {
                    perfil.ActualizarPerfil(int.Parse(txtCodigoPerfil.Text), txtNombrePerfil.Text);
                    MessageBox.Show("Perfil editado con éxito", "Editar Perfil" , MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    limpiarCampos();
                    VistaPerfil vp = new VistaPerfil();
                    vp.LlenarDataGrid();
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre de perfil para continuar", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No puede registrar un nombre repetido de perfil.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }
    }
}
