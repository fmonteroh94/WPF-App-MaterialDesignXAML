using AplicacionEscritorioWPF.VistaModelo;
using AplicacionEscritorioWPF.Vistas.Disennador.MantenedorFlujoTarea;
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

namespace AplicacionEscritorioWPF.Vistas.Disennador
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();

            PantallaPrincipal.Children.Clear();
            PantallaPrincipal.Children.Add(new Index());

            var item0 = new ItemMenu("Inicio", new Index(), PackIconKind.Home);

            var _menuPerfil = new List<SubItemMenu>();
            _menuPerfil.Add(new SubItemMenu("Agregar", new AgregarFlujoTarea()));
            _menuPerfil.Add(new SubItemMenu("Listar", new VistaFlujoTarea()));
            var item1 = new ItemMenu("Flujos de tarea", _menuPerfil, PackIconKind.Sitemap);


            MenuNagevacion.Children.Add(new MenuUsuarioDisennador(item0, this));
            MenuNagevacion.Children.Add(new MenuUsuarioDisennador(item1, this));
        }

        internal void CambiarPantalla(object sender)
        {
            var pantalla = ((UserControl)sender);

            if (pantalla != null)
            {
                PantallaPrincipal.Children.Clear();
                PantallaPrincipal.Children.Add(pantalla);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
