using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using LocadoraWpf.Views.Controls;
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

namespace LocadoraWpf.Views.Frm
{
    /// <summary>
    /// Interaction logic for frmMenuAdm.xaml
    /// </summary>
    /// 
    public partial class frmMenuAdm : Window
    {
        public usCadastrarCarro us { get; set; }

        public frmMenuAdm()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "CadastrarCarro":
                    usc = new usCadastrarCarro();
                    GridMain.Children.Add(usc);
                    break;
                case "CadastrarMoto":
                    usc = new usCadastrarMoto();
                    GridMain.Children.Add(usc);
                    break;
                case "ListarCarros":
                    usc = new usListarCarro();
                    GridMain.Children.Add(usc);
                    break;
                case "ListarMotos":
                    usc = new usListarMoto();
                    GridMain.Children.Add(usc);
                    break;
                case "ListarClientes":
                    usc = new usListaCliente();
                    GridMain.Children.Add(usc);
                    break;
                case "AprovarReserva":
                    usc = new usAprovaReservaCarro();
                    GridMain.Children.Add(usc);
                    break;

                default:
                    break;
            }
        }

        private void BtnHistoricoReserva_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new usHistoricoReserva();
            GridMain.Children.Add(usc);
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e) { this.Close(); }
    }
}
