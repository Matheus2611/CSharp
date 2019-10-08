using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using LocadoraWpf.Views.Frm;
using System;
using System.Windows;
using System.Windows.Controls;


namespace LocadoraWpf.Views.Controls
{
    /// <summary>
    /// Interaction logic for usAlugaCarro.xaml
    /// </summary>
    public partial class usAlugaCarro : UserControl
    {
        public string Parameter { get; set; }

        public usAlugaCarro(string parameter)
        {
            InitializeComponent();
            Parameter = parameter;
            ListarCarros();
        }

        public void ListarCarros()
        {
            ListaCarroAluguel.ItemsSource = VeiculoDAO.ListarCarro();
            ListaCarroAluguel.CanUserAddRows = false;
            ListaCarroAluguel.CanUserDeleteRows = false;
            ListaCarroAluguel.AutoGenerateColumns = false;
            ListaCarroAluguel.IsReadOnly = true;
        }

        private void BtnAlugar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Carro carro = ListaCarroAluguel.SelectedItem as Carro;
                if (carro == null)
                {
                    MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                frmReservaCarro frm = new frmReservaCarro(Parameter, carro.Placa);
                frm.ShowDialog();
                ListarCarros();
                GridMainAlugarCarro.Children.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
