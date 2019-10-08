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
    /// Interaction logic for usListarCarro.xaml
    /// </summary>
    public partial class usListarCarro : UserControl
    {
        public usListarCarro()
        {
            InitializeComponent();
            ListarCarro();
        }

        private void BtnEditarCarro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Carro carro = ListagemCarros.SelectedItem as Carro;
                if (carro == null)
                {
                    MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                else
                {
                    string parameter = carro.Placa;
                    frmAdmEditaCarro index = new frmAdmEditaCarro(parameter, this);
                    index.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public void ListarCarro()
        {
            ListagemCarros.ItemsSource = VeiculoDAO.ListarAllCarro();
            ListagemCarros.CanUserAddRows = false;
            ListagemCarros.IsReadOnly = true;
            ListagemCarros.AutoGenerateColumns = false;
            ListagemCarros.CanUserDeleteRows = false;
        }

        private void BtnExcluirCarro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Carro carro = ListagemCarros.SelectedItem as Carro;
                if (carro == null)
                {
                    MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Deseja realmente excluir esse registro ?", "Aviso",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    { return; }
                    VeiculoDAO.RemoverVeiculo(carro, null);
                    ListarCarro();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnPesquisa_Click(object sender, RoutedEventArgs e)
        {
            string placa = txtPesquisa.Text;
            if (string.IsNullOrWhiteSpace(txtPesquisa.Text))
            {
                MessageBox.Show("Preecha o campo pesquisa!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {

                var result = VeiculoDAO.PesquisarCarro(placa);

                if(result.Count == 0)
                {
                    MessageBox.Show("Não há registros com a placa: "+ placa, "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtPesquisa.Clear();
                    return;
                }

                ListagemCarros.ItemsSource = VeiculoDAO.PesquisarCarro(placa);
                ListagemCarros.CanUserAddRows = false;
                ListagemCarros.IsReadOnly = true;
                ListagemCarros.AutoGenerateColumns = false;
                ListagemCarros.CanUserDeleteRows = false;
            }
        }
    }
}
