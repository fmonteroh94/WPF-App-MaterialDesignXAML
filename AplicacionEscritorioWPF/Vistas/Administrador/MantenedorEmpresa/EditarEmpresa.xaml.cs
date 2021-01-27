using ProcessSA.BLL;
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
using System.Windows.Shapes;

namespace AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa
{
    /// <summary>
    /// Lógica de interacción para EditarEmpresa.xaml
    /// </summary>
    public partial class EditarEmpresa : Window
    {
        public EditarEmpresa(string _codigo, string _rut, string _dv, string _nom, string _rz, string _dir, string _eml)
        {
            InitializeComponent();
            txtCodigo.Text = _codigo;
            txtRut.Text = _rut;
            txtDvRut.Text = _dv;
            txtNombre.Text = _nom;
            txtRazonSocial.Text = _rz;
            txtDireccion.Text = _dir;
            txtEmail.Text = _eml;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text == string.Empty || txtDvRut.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un rut", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (txtRazonSocial.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una razón social", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (txtDireccion.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una dirección", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (txtRazonSocial.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un correo electrónico", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Empresa_BLC empresa = new Empresa_BLC();
                int _id = int.Parse(txtCodigo.Text);
                int _rut = int.Parse(txtRut.Text);
                char _dv = char.Parse(txtDvRut.Text);
                string _nombre = txtNombre.Text;
                string _razon = txtRazonSocial.Text;
                string _direccion = txtDireccion.Text;
                string _email = txtEmail.Text;
                try
                {
                    empresa.ActualizarEmpresa(_id,_rut, _dv, _nombre, _razon, _direccion, _email);
                    MessageBox.Show("Empresa editada con éxito", "Editar Empresa", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al intentar editar la empresa seleccionada. Por favor verifique que los campos ingresados son válidos e inténtelo nuevamente. Si el problema persiste, contacte con su administrador de sistemas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
