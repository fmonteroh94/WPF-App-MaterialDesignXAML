using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AplicacionEscritorioWPF.VistaModelo
{
    public class SubItemMenu
    {
        public SubItemMenu(string nombre, UserControl pantalla = null)
        {
            Nombre = nombre;
            Pantalla = pantalla;
        }

        public string Nombre { get; private set; }
        public UserControl Pantalla { get; private set; }
    }
}
