using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LocadoraWpf.Views.Frm
{
    /// <summary>
    /// Interaction logic for FrmCadCliente.xaml
    /// </summary>
    public partial class FrmCadCliente : Window
    {
        public FrmCadCliente()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            try
            {

                if (ValidaCamposEmBranco())
                {
                    #region Dados do cliente para cadastro
                    cliente.Nome = txtName.Text;
                    cliente.Rg = txtRg.Text;
                    cliente.Cpf = txtCpf.Text;
                    cliente.Telefone = txtTelefone.Text;
                    cliente.Senha = txtSenha.Password;
                    cliente.Cnh = txtCnh.Text;
                    cliente.Endereco.Numero = Convert.ToInt32(txtNumero.Text);
                    cliente.Endereco.Bairro = txtBairro.Text;
                    cliente.Endereco.Cidade = txtCidade.Text;
                    cliente.Endereco.Estado = txtEstado.Text;
                    cliente.Endereco.Rua = txtRua.Text;
                    ComboBoxItem item = (ComboBoxItem)cboCategoriaCNH.SelectedItem;
                    cliente.CategoriaCnh = item.Content.ToString();
                    cliente.Status = "ATIVO";
                    #endregion

                    if (ClienteDAO.CadastrarCliente(cliente))
                    {
                        MessageBox.Show("Cliente Cadastrado!!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else { MessageBox.Show("Cpf ja cadastrado!!", "", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
                else { MessageBox.Show("Favor preencher as informações!", "Mensagem", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public bool ValidaCamposEmBranco()
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtRg.Text) && !string.IsNullOrEmpty(txtCpf.Text) &&
                !string.IsNullOrEmpty(txtTelefone.Text) && !string.IsNullOrEmpty(cboCategoriaCNH.Text) && !string.IsNullOrEmpty(txtSenha.Password) &&
                !string.IsNullOrEmpty(txtCnh.Text) && !string.IsNullOrEmpty(txtNumero.Text) && !string.IsNullOrEmpty(txtBairro.Text) &&
                !string.IsNullOrEmpty(txtCidade.Text) && !string.IsNullOrEmpty(txtEstado.Text) && !string.IsNullOrEmpty(cboCategoriaCNH.Text))
            {
                return true;
            }
            return false;
        }

        private void CboCategoriaCNH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
