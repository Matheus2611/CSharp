using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using LocadoraWpf.Views.Frm;
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

namespace LocadoraWpf.Views.Controls
{
    /// <summary>
    /// Interaction logic for usAlugarMoto.xaml
    /// </summary>
    public partial class usAlugarMoto : UserControl
    {
        public string Parameter { get; set; }
        public usAlugarMoto(string parameter)
        {
            InitializeComponent();
            Parameter = parameter;
            ListarMotos();
        }
        public void ListarMotos()
        {
            ListaMotoAluguel.ItemsSource = VeiculoDAO.ListarMoto();
            ListaMotoAluguel.CanUserAddRows = false;
            ListaMotoAluguel.CanUserDeleteRows = false;
            ListaMotoAluguel.AutoGenerateColumns = false;
            ListaMotoAluguel.IsReadOnly = true;
        }

        private void BtnAlugar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Moto moto = ListaMotoAluguel.SelectedItem as Moto;
                if (moto == null)
                {
                    MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                frmReservaMoto frm = new frmReservaMoto(Parameter, moto.Placa);
                frm.ShowDialog();
                ListarMotos();
                GridMainAlugarMoto.Children.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
