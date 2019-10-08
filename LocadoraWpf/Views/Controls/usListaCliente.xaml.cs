using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using LocadoraWpf.Views.Frm;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LocadoraWpf.Views.Controls
{

    /// <summary>
    /// Interaction logic for usListaCliente.xaml
    /// </summary>
    public partial class usListaCliente : UserControl
    {
        public usListaCliente()
        {
            InitializeComponent();
            ListarClientes();
        }

        private void BtnExcluirCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cliente = ListagemCliente.SelectedItem as Cliente;

                if (cliente == null)
                {
                    MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                else
                {
                    if (MessageBox.Show("Deseja realmente excluir esse registro ?", "Aviso",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) { return; }
                    if (ClienteDAO.RemoverCliente(cliente)) { ListarClientes(); }
                    else { MessageBox.Show("Essa conta possui uma reserva! \n Não pode ser excluida!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
                }
            }
            catch (Exception ex) { MessageBox.Show("Essa conta pertence ao histórico de reservas \n Não há como excluir!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = ListagemCliente.SelectedItem as Cliente;
            if (cliente == null)
            {
                MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                string parameter = cliente.Cpf;
                frmAdmEditaCliente index = new frmAdmEditaCliente(parameter, this);
                index.ShowDialog();
            }

        }

        public void ListarClientes()
        {
            ListagemCliente.ItemsSource = ClienteDAO.ListarCliente();
            ListagemCliente.CanUserAddRows = false;
            ListagemCliente.IsReadOnly = true;
            ListagemCliente.AutoGenerateColumns = false;
            ListagemCliente.CanUserDeleteRows = false;
        }

        private void BtnPesquisa_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtPesquisa.Text;
            if (string.IsNullOrWhiteSpace(txtPesquisa.Text))
            {
                MessageBox.Show("Preecha o campo pesquisa!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                var result = ClienteDAO.BuscarCliente(nome);

                if (result.Count == 0)
                {
                    MessageBox.Show("Não há registros com o nome: " + nome ,"LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtPesquisa.Clear();
                    return;
                }

                ListagemCliente.ItemsSource = ClienteDAO.BuscarCliente(nome);
                ListagemCliente.CanUserAddRows = false;
                ListagemCliente.IsReadOnly = true;
                ListagemCliente.AutoGenerateColumns = false;
                ListagemCliente.CanUserDeleteRows = false;
            }
        }
    }
}
