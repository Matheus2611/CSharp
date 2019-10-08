using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using LocadoraWpf.Views.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LocadoraWpf.Views.Frm
{
    /// <summary>
    /// Interaction logic for frmAdmEditaCliente.xaml
    /// </summary>
    public partial class frmAdmEditaCliente : Window
    {
        public string Parameter { get; set; }

        public usListaCliente us { get; set; }

        public frmAdmEditaCliente(string parameter, usListaCliente us)
        {
            this.us = us;
            Parameter = parameter;
            InitializeComponent();
            #region Dados do cliente
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
            txtStatus.Text = cliente.Status;
            #endregion
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();

                if (ValidaCamposEmBranco())
                {
                    cliente.Cpf = Parameter;
                    cliente = ClienteDAO.Get(cliente);
                    #region Dados do cliente para cadastro
                    cliente.Nome = txtName.Text;
                    cliente.Telefone = txtTelefone.Text;
                    cliente.Senha = txtSenha.Password;
                    ComboBoxItem item = (ComboBoxItem)cboCategoriaCNH.SelectedItem;
                    cliente.CategoriaCnh = item.Content.ToString();
                    cliente.Endereco.Numero = Convert.ToInt32(txtNumero.Text);
                    cliente.Endereco.Bairro = txtBairro.Text;
                    cliente.Endereco.Cidade = txtCidade.Text;
                    cliente.Endereco.Estado = txtEstado.Text;
                    cliente.Endereco.Rua = txtRua.Text;
                    cliente.Status = txtStatus.Text;
                    #endregion

                    ClienteDAO.AlterarDadosCliente(cliente);
                    MessageBox.Show("Dados alterados com sucesso!!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                    us.ListarClientes();
                    Close();
                }
                else { MessageBox.Show("Favor preencher as informações!", "Mensagem", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public bool ValidaCamposEmBranco()
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtTelefone.Text) && !string.IsNullOrEmpty(cboCategoriaCNH.Text) &&
                !string.IsNullOrEmpty(txtSenha.Password) && !string.IsNullOrEmpty(txtNumero.Text) && !string.IsNullOrEmpty(txtBairro.Text) &&
                !string.IsNullOrEmpty(txtCidade.Text) && !string.IsNullOrEmpty(txtEstado.Text))
            { return true; }
            return false;
        }

        public void LimparCampos()
        {
            txtName.Clear();
            txtSenha.Clear();
            txtTelefone.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            txtEstado.Clear();
        }
    }

}
