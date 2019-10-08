using LocadoraWpf.DAL;
using LocadoraWpf.Models;
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
    /// Interaction logic for FrmPrincipal.xaml
    /// </summary>
    public partial class FrmPrincipal : Window
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Administrador adm = new Administrador();
                Cliente cliente = new Cliente();
                cliente.Cpf = txtLogin.Text;
                cliente.Senha = txtSenha.Password;

                if (ClienteDAO.AutenticarLogin(cliente))
                {
                    if (ClienteDAO.ConfereStatus(cliente))
                    {
                        
                        txtLogin.Clear();
                        txtSenha.Clear();
                        frmMenuCliente index = new frmMenuCliente(cliente.Cpf);
                        index.Parameter = cliente.Cpf;
                        index.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sua conta foi  cancela!! \n Para Ativa-la  novamente contate o administrador.",
                            "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
                else if (cliente.Cpf.ToUpper().Equals(adm.Login) && cliente.Senha.ToUpper().Equals(adm.Senha))
                {
                    txtLogin.Clear();
                    txtSenha.Clear();
                    frmMenuAdm index = new frmMenuAdm();
                    index.ShowDialog();
                }
                else { MessageBox.Show("Login ou Senha Incorretos!!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnCadastreSe_Click(object sender, RoutedEventArgs e)
        {
            FrmCadCliente index = new FrmCadCliente();
            index.ShowDialog();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e) { this.Close(); }
    }
}
