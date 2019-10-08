using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using LocadoraWpf.Views.Frm;
using System.Windows;
using System.Windows.Controls;

namespace LocadoraWpf.Views.Controls
{
    /// <summary>
    /// Interaction logic for usListarMoto.xaml
    /// </summary>
    public partial class usListarMoto : UserControl
    {
        public usListarMoto()
        {
            InitializeComponent();
            ListarMoto();
        }

        public void ListarMoto()
        {
            ListagemMotos.ItemsSource = VeiculoDAO.ListarAllMoto();
            ListagemMotos.CanUserAddRows = false;
            ListagemMotos.IsReadOnly = true;
            ListagemMotos.AutoGenerateColumns = false;
            ListagemMotos.CanUserDeleteRows = false;
        }

        private void BtnEditarMoto_Click(object sender, RoutedEventArgs e)
        {
            Moto moto = ListagemMotos.SelectedItem as Moto;

            if (moto == null)
            {
                MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            else
            {
                string parameter = moto.Placa;
                frmAdmEditaMoto index = new frmAdmEditaMoto(parameter, this);
                index.ShowDialog();
            }
        }

        private void BtnExcluirMoto_Click(object sender, RoutedEventArgs e)
        {
            Moto moto = ListagemMotos.SelectedItem as Moto;

            if (moto == null)
            {
                MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            else
            {
                if (MessageBox.Show("Deseja realmente excluir esse registro ?", "Aviso",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                { return; }

                VeiculoDAO.RemoverVeiculo(null, moto);
                ListarMoto();
            }
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
                var result = VeiculoDAO.PesquisarMoto(placa);
                if (result.Count == 0)
                {
                    MessageBox.Show("Não há registros com a placa: " + placa, "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtPesquisa.Clear();
                    return;
                }

                ListagemMotos.ItemsSource = VeiculoDAO.PesquisarMoto(placa);
                ListagemMotos.CanUserAddRows = false;
                ListagemMotos.IsReadOnly = true;
                ListagemMotos.AutoGenerateColumns = false;
                ListagemMotos.CanUserDeleteRows = false;
            }

        }
    }
}
