using AplicacionEscritorioWPF.VistaModelo;
using AplicacionEscritorioWPF.Vistas.Administrador.MantenedorPerfil;
using AplicacionEscritorioWPF.Vistas.Administrador.MantenedorCargo;
using AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa;
using AplicacionEscritorioWPF.Vistas.Administrador.MantenedorUsuario;
using AplicacionEscritorioWPF.Vistas.Menu;
using MaterialDesignThemes.Wpf;
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
using AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorArea;
using AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorDepartamento;
using AplicacionEscritorioWPF.Vistas.Administrador.MantenedorEmpresa.MantenedorFuncion;

namespace AplicacionEscritorioWPF.Vistas.Administrador
{
    /// <summary>
    /// Lógica de interacción para PanelControl.xaml
    /// </summary>
    public partial class PanelControl : Window
    {
        public PanelControl()
        {
            InitializeComponent();

            PantallaPrincipal.Children.Clear();
            PantallaPrincipal.Children.Add(new Inicio());

            var item0 = new ItemMenu("Inicio", new Inicio(), PackIconKind.Home);

            var _menuPerfil = new List<SubItemMenu>();
            _menuPerfil.Add(new SubItemMenu("Agregar", new AgregarPerfil()));
            _menuPerfil.Add(new SubItemMenu("Listar", new VistaPerfil()));
            var item1 = new ItemMenu("Perfiles", _menuPerfil, PackIconKind.UserGroup);

            var _menuCargo = new List<SubItemMenu>();
            _menuCargo.Add(new SubItemMenu("Agregar", new AgregarCargo()));
            _menuCargo.Add(new SubItemMenu("Listar", new VistaCargo()));
            var item2 = new ItemMenu("Cargos", _menuCargo, PackIconKind.BagSuitcaseOff);

            var _menuUsuario = new List<SubItemMenu>();
            _menuUsuario.Add(new SubItemMenu("Agregar", new AgregarUsuario()));
            _menuUsuario.Add(new SubItemMenu("Listar", new VistaUsuario()));
            var item3 = new ItemMenu("Usuarios", _menuUsuario, PackIconKind.User);

            var _menuEmpresa = new List<SubItemMenu>();
            _menuEmpresa.Add(new SubItemMenu("Agregar empresa", new AgregarEmpresa()));
            _menuEmpresa.Add(new SubItemMenu("Listar empresas", new VistaEmpresa()));
            _menuEmpresa.Add(new SubItemMenu("Agregar área", new AgregarArea()));
            _menuEmpresa.Add(new SubItemMenu("Listar áreas", new ListarAreas()));
            _menuEmpresa.Add(new SubItemMenu("Agregar departamento", new AgregarDepartamento()));
            _menuEmpresa.Add(new SubItemMenu("Listar departamentos", new ListarDepartamentos()));
            _menuEmpresa.Add(new SubItemMenu("Agregar función", new AgregarFuncion()));
            _menuEmpresa.Add(new SubItemMenu("Listar funciones", new ListarFunciones()));
            var item4 = new ItemMenu("Empresas", _menuEmpresa, PackIconKind.Building);

            MenuNagevacion.Children.Add(new MenuControlUsuario(item0, this));
            MenuNagevacion.Children.Add(new MenuControlUsuario(item1, this));
            MenuNagevacion.Children.Add(new MenuControlUsuario(item2, this));
            MenuNagevacion.Children.Add(new MenuControlUsuario(item3, this));
            MenuNagevacion.Children.Add(new MenuControlUsuario(item4, this));
        }

       internal void CambiarPantalla(object sender) 
        {
            var pantalla = ((UserControl) sender);

            if (pantalla != null)
            {
                PantallaPrincipal.Children.Clear();
                PantallaPrincipal.Children.Add(pantalla);
            }

        }

        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
