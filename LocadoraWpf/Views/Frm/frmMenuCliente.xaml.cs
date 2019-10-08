using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using LocadoraWpf.Views.Controls;
using System.Windows;
using System.Windows.Controls;


namespace LocadoraWpf.Views.Frm
{
    /// <summary>
    /// Interaction logic for frmMenuCliente.xaml
    /// </summary>
    public partial class frmMenuCliente : Window
    {
        public string Parameter { get; set; }

        public frmMenuCliente(string parameter)
        {
            Parameter = parameter;
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;

        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "AlugarCarro":

                    Cliente c = new Cliente();
                    c.Cpf = Parameter;
                    c = ClienteDAO.Get(c);
                    if ((c.CategoriaCnh.Equals("B") || c.CategoriaCnh.Equals("AB")) && c.PossuiReserva.Equals("NAO"))
                    {
                        usc = new usAlugaCarro(Parameter);
                        GridMain.Children.Add(usc);
                    }
                    else
                    {
                        MessageBox.Show("Sua Categoria Só Permite Aluguel De Motos!!" +
                            " ou Você ja possui um veiculo alugado!", "LocadoraWPF",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        frmMenuCliente f = new frmMenuCliente(Parameter);
                        f.ShowDialog();
                        Close();
                    }
                    break;

                case "AlugarMoto":
                    c = new Cliente();
                    c.Cpf = Parameter;
                    c = ClienteDAO.Get(c);
                    if ((c.CategoriaCnh.Equals("A") || c.CategoriaCnh.Equals("AB")) && c.PossuiReserva.Equals("NAO"))
                    {
                        usc = new usAlugarMoto(Parameter);
                        GridMain.Children.Add(usc);
                    }
                    else
                    {
                        MessageBox.Show("Sua Categoria Só Permite Aluguel De Carros!!" +
                            " ou Você ja possui um veiculo alugado!", "LocadoraWPF",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        frmMenuCliente f = new frmMenuCliente(Parameter);
                        f.ShowDialog();
                        Close();
                    }
                    break;

                case "Devolucao":
                    usc = new usDevolucao(Parameter);
                    GridMain.Children.Add(usc);
                    break;

                default:
                    break;
            }
        }
        private void BtnAlterarDados_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = null;
            usc = new usEditarCliente(Parameter);
            GridMain.Children.Add(usc);

        }

        private void BtnExcluirConta_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Cpf = Parameter;
            if (ClienteDAO.RemoverCliente(cliente))
            {
                MessageBox.Show("Conta Excluida!");
                this.Close();
            }
            else { MessageBox.Show("Essa conta não pode ser excluida!! \n Faça a devolução do veiculo!","LocadoraWPF",MessageBoxButton.OK,MessageBoxImage.Warning); }

        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e) { this.Close(); }
    }
}
