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
using LiveCharts;
using LiveCharts.Wpf;
using ProcessSA.BLL;

namespace AplicacionEscritorioWPF.Vistas.Administrador
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : UserControl
    {
        

        public Inicio()
        {
            InitializeComponent();
            LlenarGrafico();
        }

        public void LlenarGrafico()
        {
            Usuario_BLC usr = new Usuario_BLC();
            DataTable dt = usr.CantidadUsuariosPerfil();
            SeriesCollection series = new SeriesCollection();
            chtUsuarios.DataContext = dt;
            foreach (DataRow row in dt.Rows)
            {
                series.Add(new PieSeries() { Title = row["Perfil"].ToString(), Values = new ChartValues<int> { int.Parse(row["Cantidad"].ToString()) }, DataLabels = true });
                chtUsuarios.Series = series;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarGrafico();
        }
    }
}
