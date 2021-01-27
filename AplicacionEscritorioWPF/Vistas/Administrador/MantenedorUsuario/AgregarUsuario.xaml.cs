using ProcessSA.BLL;
using AplicacionEscritorioWPF.VistaModelo;
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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorUsuario
{
    /// <summary>
    /// Lógica de interacción para AgregarUsuario.xaml
    /// </summary>
    public partial class AgregarUsuario : UserControl
    {
        public AgregarUsuario()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            cbxPerfil.DataContext = null;
            Perfil_BLC perfiles = new Perfil_BLC();
            DataTable dtp = perfiles.ListarPerfiles();
            cbxPerfil.ItemsSource = dtp.DefaultView;
            cbxPerfil.DisplayMemberPath = "TIPO";
            cbxPerfil.SelectedValuePath = "IDPERFIL";

            cbxCargo.DataContext = null;
            Cargo_BLC cargos = new Cargo_BLC();
            DataTable dtc = cargos.ListarCargos();
            cbxCargo.ItemsSource = dtc.DefaultView;
            cbxCargo.DisplayMemberPath = "NOMBRE";
            cbxCargo.SelectedValuePath = "IDCARGO";

            cbxEmpresa.DataContext = null;
            Empresa_BLC empresas = new Empresa_BLC();
            DataTable dte = empresas.ListarEmpresas();
            cbxEmpresa.ItemsSource = dte.DefaultView;
            cbxEmpresa.DisplayMemberPath = "NOMBRE";
            cbxEmpresa.SelectedValuePath = "IDEMPRESA";

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPass.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una contraseña de usuario", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (txtNombres.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar los nombres", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (txtPaterno.Text == string.Empty && txtMaterno.Text == string.Empty || txtPaterno.Text == string.Empty || txtMaterno.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar los apellidos", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (txtPass2.Text == string.Empty && txtPass.Text != string.Empty)
            {
                MessageBox.Show("Debe confirmar la contraseña ingresada", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (txtPass.Text != txtPass2.Text)
            {
                MessageBox.Show("Las contraseñas deben coincidir", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (cbxPerfil.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un perfil de usuario", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (cbxCargo.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cargo", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (cbxEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una empresa", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Usuario_BLC usuario = new Usuario_BLC();
                string _nombres = txtNombres.Text;
                string _paterno = txtPaterno.Text;
                string _materno = txtMaterno.Text;
                string _user = txtUsuario.Text;
                string _pass = Encriptacion.EncriptarSha256(txtPass.Text);
                string _email = txtEmail.Text;
                int _idperfil = int.Parse(cbxPerfil.SelectedValue.ToString());
                int _idcargo = int.Parse(cbxCargo.SelectedValue.ToString());
                int _idempresa = int.Parse(cbxEmpresa.SelectedValue.ToString());

                try
                {
                    usuario.InsertarUsuario(_nombres, _paterno, _materno, _user, _pass, _email, DateTime.Now, DateTime.Now, _idperfil, _idcargo, _idempresa);
                    MessageBox.Show("Usuario ingresado con éxito", "Registrar Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al intentar registrar el usuario. Por favor verifique que los campos ingresados son válidos e inténtelo nuevamente. Si el problema persiste, contacte con su administrador de sistemas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
