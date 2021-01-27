using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AplicacionEscritorioWPF.VistaModelo
{
    public class ItemMenu
    {
        public ItemMenu(string encabezado, List<SubItemMenu> subItems, PackIconKind icono)
        {
            Encabezado = encabezado;
            SubItems = subItems;
            Icono = icono;
        }

        public ItemMenu(string encabezado, UserControl pantalla, PackIconKind icono)
        {
            Encabezado = encabezado;
            Pantalla = pantalla;
            Icono = icono;
        }

        public string Encabezado { get; private set; }
        public PackIconKind Icono { get; private set; }
        public List<SubItemMenu> SubItems { get; private set; }
        public UserControl Pantalla { get; private set; }
    }
}
