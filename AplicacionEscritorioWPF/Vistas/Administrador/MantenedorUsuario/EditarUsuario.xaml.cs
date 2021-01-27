using AplicacionEscritorioWPF.VistaModelo;
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

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorUsuario
{
    /// <summary>
    /// Lógica de interacción para EditarUsuario.xaml
    /// </summary>
    public partial class EditarUsuario : Window
    {

        public EditarUsuario(string _codigo, string _nombres, string _paterno, string _materno, string _usuario, string _pass,  string _email, string _perfil, string _cargo, string _empresa)
        {
            InitializeComponent();
            LlenarComboBox(int.Parse(_perfil), int.Parse(_cargo), int.Parse(_empresa));
            txtCodigo.Text = _codigo;
            txtNombres.Text = _nombres;
            txtPaterno.Text = _paterno;
            txtMaterno.Text = _materno;
            txtUsuario.Text = _usuario;
            txtEmail.Text = _email;
        }

        private void LlenarComboBox(int _perfil, int _cargo, int _empresa)
        {
            cbxPerfil.DataContext = null;
            Perfil_BLC perfiles = new Perfil_BLC();
            DataTable dtp = perfiles.ListarPerfiles();
            cbxPerfil.ItemsSource = dtp.DefaultView;
            cbxPerfil.DisplayMemberPath = "TIPO";
            cbxPerfil.SelectedValuePath = "IDPERFIL";
            cbxPerfil.SelectedValue = _perfil;

            cbxCargo.DataContext = null;
            Cargo_BLC cargos = new Cargo_BLC();
            DataTable dtc = cargos.ListarCargos();
            cbxCargo.ItemsSource = dtc.DefaultView;
            cbxCargo.DisplayMemberPath = "NOMBRE";
            cbxCargo.SelectedValuePath = "IDCARGO";
            cbxCargo.SelectedIndex = _cargo;

            cbxEmpresa.DataContext = null;
            Empresa_BLC empresas = new Empresa_BLC();
            DataTable dte = empresas.ListarEmpresas();
            cbxEmpresa.ItemsSource = dte.DefaultView;
            cbxEmpresa.DisplayMemberPath = "NOMBRE";
            cbxEmpresa.SelectedValuePath = "IDEMPRESA";
            cbxEmpresa.SelectedIndex = _empresa;

        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPass.Text == string.Empty && txtPass2.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una contraseña de usuario", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                int _codigo = int.Parse(txtCodigo.Text);
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
                    usuario.ActualizarUsuario(_codigo, _nombres, _paterno, _materno, _user, _pass, _email, _idperfil, _idcargo, _idempresa);
                    MessageBox.Show("Usuario editado con éxito", "Editar Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un Error. Intente de nuevo");
                }
            }
        }
    }
}
