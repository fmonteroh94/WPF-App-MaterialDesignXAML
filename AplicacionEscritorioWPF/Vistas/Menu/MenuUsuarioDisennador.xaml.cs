using AplicacionEscritorioWPF.VistaModelo;
using AplicacionEscritorioWPF.Vistas.Disennador;
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

namespace AplicacionEscritorioWPF.Vistas.Menu
{
    /// <summary>
    /// Lógica de interacción para MenuUsuarioDisennador.xaml
    /// </summary>
    public partial class MenuUsuarioDisennador : UserControl
    {
        Dashboard _context;

        public MenuUsuarioDisennador(ItemMenu itemMenu, Dashboard context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ListViewItemMenu_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _context.CambiarPantalla(((ItemMenu)((ListBoxItem)sender).DataContext).Pantalla);
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _context.CambiarPantalla(((TextBlock)sender).Tag);
        }

    }
}
