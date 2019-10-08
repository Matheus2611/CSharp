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
    /// Interaction logic for usEditarCliente.xaml
    /// </summary>
    public partial class usEditarCliente : UserControl
    {
        string cpf;
        string rg;
        string cnh;
        int id;
        string Parameter { get; set; }

        public usEditarCliente(string parameter)
        {
            InitializeComponent();
            #region Dados do cliente
            Parameter = parameter;
            Cliente cliente = new Cliente();
            cliente.Cpf = parameter;
            cliente = ClienteDAO.Get(cliente);
            txtName.Text = cliente.Nome;
            txtTelefone.Text = cliente.Telefone;
            cboCategoriaCNH.Text = cliente.CategoriaCnh;
            txtSenha.Password = cliente.Senha;
            txtNumero.Text = cliente.Endereco.Numero.ToString();
            txtBairro.Text = cliente.Endereco.Bairro;
            txtCidade.Text = cliente.Endereco.Cidade;
            txtEstado.Text = cliente.Endereco.Estado;
            txtRua.Text = cliente.Endereco.Rua;
            cpf = cliente.Cpf;
            rg = cliente.Rg;
            cnh = cliente.Cnh;
            id = cliente.IdCliente;
            #endregion
        }

        private void BtnCadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();

                if (ValidaCamposEmBranco())
                {
                    cliente.Cpf = cpf;
                    cliente = ClienteDAO.Get(cliente);
                    #region Dados do cliente para cadastro
                    cliente.Nome = txtName.Text;
                    cliente.Telefone = txtTelefone.Text;
                    ComboBoxItem item = (ComboBoxItem)cboCategoriaCNH.SelectedItem;
                    cliente.CategoriaCnh = item.Content.ToString();
                    cliente.Senha = txtSenha.Password;
                    cliente.Endereco.Numero = Convert.ToInt32(txtNumero.Text);
                    cliente.Endereco.Bairro = txtBairro.Text;
                    cliente.Endereco.Cidade = txtCidade.Text;
                    cliente.Endereco.Estado = txtEstado.Text;
                    cliente.Endereco.Rua = txtRua.Text;
                    cliente.Rg = rg;
                    cliente.Cnh = cnh;
                    #endregion

                    ClienteDAO.AlterarDadosCliente(cliente);

                    MessageBox.Show("Dados alterados com sucesso!!", "LocaodoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else { MessageBox.Show("Favor preencher as informações!", "LocaodoraWPF", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocaodoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public bool ValidaCamposEmBranco()
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtTelefone.Text) && !string.IsNullOrEmpty(cboCategoriaCNH.Text) &&
                !string.IsNullOrEmpty(txtSenha.Password) && !string.IsNullOrEmpty(txtNumero.Text) && !string.IsNullOrEmpty(txtBairro.Text) &&
                !string.IsNullOrEmpty(txtCidade.Text) && !string.IsNullOrEmpty(txtEstado.Text))
            {
                return true;
            }
            return false;
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            GridMainEditarCliente.Children.Clear();
        }
    }
}
