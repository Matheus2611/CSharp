using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LocadoraWpf.Views.Controls
{
    /// <summary>
    /// Interaction logic for usDevolucao.xaml
    /// </summary>
    public partial class usDevolucao : UserControl
    {
        public string Parameter { get; set; }

        #region instancias
        static List<Reserva> listReserva = new List<Reserva>();
        static Moto moto = new Moto();
        static Carro carro = new Carro();
        static Cliente cliente = new Cliente();
        Reserva reserva = new Reserva();
        //static Devolucao devolucao = new Devolucao();
        Pagamento pagamento = new Pagamento();
        #endregion

        public static double pgto { get; set; }

        public static int cartao { get; set; }

        public usDevolucao(string parameter)
        {
            InitializeComponent();
            pgto = 0;

            Parameter = parameter;
            cliente.Cpf = parameter;
            cliente = ClienteDAO.Get(cliente);
            string status = null;
            if (cliente.CarroId == 0)
            {
                listReserva = ReservaDAO.GetReservaMoto(parameter, cliente.MotoId);
                foreach (var item in listReserva) { status = item.Status; }
            }
            if (cliente.MotoId == 0)
            {
                listReserva = ReservaDAO.GetReservaCarro(parameter, cliente.CarroId);
                foreach (var item in listReserva) { status = item.Status; }
            }

            if ((listReserva.Count == 0 || cliente.PossuiReserva.Equals("NAO")) || status.Equals("PENDENTE"))
            {
                MessageBox.Show("Não possui reserva para fazer devolução ou sua reserva não foi aprovada!");
                GridMainDevolucao.Children.Clear();
                return;
            }
            if (status.Equals("CANCELADA"))
            {
                MessageBox.Show("Sua reserva não foi aprovada pelo Administrador!!");
                GridMainDevolucao.Children.Clear();
                return;
            }

            foreach (var item in listReserva)
            {
                reserva.IdReserva = item.IdReserva;
                reserva = ReservaDAO.GetReserva(reserva);
                txtDataReserva.Text = reserva.DataDevolucao.ToString("dd/MM/yyyy HH:mm");

                if (item.Carro == null) { reserva.Moto = item.Moto; }
                if (item.Moto == null) { reserva.Carro = item.Carro; }
                reserva.Cliente = item.Cliente;
            }

        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dtDevolucao.Text) || string.IsNullOrWhiteSpace(cboHoraDevolucao.Text) || dtDevolucao.SelectedDate == null)
                {
                    MessageBox.Show("Preencha os campos em branco!");
                    return;
                }
             
                else
                {
                    dtDevolucao.IsEnabled = false;
                    cboHoraDevolucao.IsEnabled = false;
                    DateTime? dtD = dtDevolucao.SelectedDate;
            
                    if (dtDevolucao.SelectedDate == null)
                    {
                        MessageBox.Show("Preencha os Campos em branco!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    ComboBoxItem itemD = (ComboBoxItem)cboHoraDevolucao.SelectedItem;

                    if (cboHoraDevolucao.SelectedItem == null)
                    {
                        MessageBox.Show("Preencha os Campos em branco!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                        dtDevolucao.IsEnabled = true;
                        cboHoraDevolucao.IsEnabled = true;
                        return;
                    }

                    int horaDevolucao = Convert.ToInt32(itemD.Content.ToString().Replace(":00", ""));

                    reserva.DataDevolucao = Convert.ToDateTime(dtD.Value.AddHours(horaDevolucao));

                    if (reserva.DataDevolucao.Day < reserva.DataDevolucao.Day &&
                        reserva.DataDevolucao.DayOfWeek < reserva.DataDevolucao.DayOfWeek &&
                        reserva.DataDevolucao.DayOfYear < reserva.DataDevolucao.DayOfYear)
                    {
                        MessageBox.Show("A Data de devolução não pode ser menor do que a data de devolução prevista!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Warning);
                        dtDevolucao.IsEnabled = true;
                        cboHoraDevolucao.IsEnabled = true;
                        return;
                    }
                    else
                    {
                        double valorTotalPgto = DevolucaoDAO.CalcularValorDevolucao(reserva, reserva.DataDevolucao);
                        txtValorTotal.Text = valorTotalPgto.ToString();
                        btnDinheiro.IsEnabled = true;
                        btnCredito.IsEnabled = true;
                        btnDebito.IsEnabled = true;
                        btnCalcular.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            pagamento = new Pagamento();
            if (string.IsNullOrWhiteSpace(txtNroCartao.Text))
            {
                MessageBox.Show("Insira o numero do cartão", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (txtNroCartao.Text.Length < 16)
            {
                MessageBox.Show("É necessário 16 digitos para validar o cartão!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                pagamento.ValorTotalReserva = Convert.ToDouble(txtValorTotal.Text);
                pagamento.DataHoraPagamento = DateTime.Now;
                pagamento.NroCartao = txtNroCartao.Text;
                long nro = Convert.ToInt64(pagamento.NroCartao);
                if (nro < 0)
                {
                    MessageBox.Show("Somente numeros inteiros!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                pagamento.Cliente = cliente;
                if (cartao == 0) pagamento.Debito = true;
                if (cartao == 1) pagamento.Credito = true;
                DevolucaoDAO.SalvarDevolucaoPagamento(reserva, pagamento);
                MessageBox.Show("Executado com sucesso!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                GridMainDevolucao.IsEnabled = false;
            }
            //}
            //catch (Exception ex) { /*MessageBox.Show(ex.ToString());*/ }
        }

        private void BtnPagar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPagamento.Text))
                {
                    MessageBox.Show("Preencha o valor do pagamento!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                else
                {
                    pagamento.ValorTotalReserva = Convert.ToDouble(txtValorTotal.Text);
                    //if (pagamento.ValorPagamento <= 0)
                    //{
                    //    MessageBox.Show("Somente valores positivos", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    return;
                    //}
                    pgto = +Convert.ToDouble(txtPagamento.Text);
                    pagamento.ValorPagamento = pgto;

                    if (!CalcularPgto())
                    {
                        txtValorTotal.Text = pagamento.ValorTroco.ToString();
                        txtPagamento.Clear();
                    }
                    else
                    {
                        pagamento.ValorTotalReserva = Convert.ToDouble(txtValorTotal.Text);
                        pagamento.DataHoraPagamento = DateTime.Now;
                        pagamento.ValorPagamento = pgto;
                        pagamento.Cliente = cliente;
                        pagamento.Dinheiro = true;
                        DevolucaoDAO.SalvarDevolucaoPagamento(reserva, pagamento);
                        MessageBox.Show("Executado com sucesso!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                        GridMainDevolucao.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex) { /*MessageBox.Show(ex.ToString());*/ }

        }

        public bool CalcularPgto()
        {
            try
            {
                pagamento.ValorTroco = PagamentoDAO.Pagamento(pagamento);
                if (pagamento.ValorPagamento > pagamento.ValorTotalReserva)
                {
                    MessageBox.Show("Pagamento Efetuado com Sucesso!\n Seu troco é: " + pagamento.ValorTroco.ToString("C2"), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }

                else if (pagamento.ValorTotalReserva == pagamento.ValorTroco)
                {
                    MessageBox.Show("Pagamento Efetuado com Sucesso!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    return true;
                }
                else if (pagamento.ValorTroco > pagamento.ValorTotalReserva)
                {
                    MessageBox.Show("Pagamento Efetuado com Sucesso!\n Seu troco é: " + pagamento.ValorTroco.ToString("C2"), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Pagamento insuficiente!!\n Faltam: " + pagamento.ValorTroco.ToString("C2"), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void BtnDebito_Click(object sender, RoutedEventArgs e)
        {
            cartao = 0;
            pagamento.Debito = true;
            txtNroCartao.IsEnabled = true;
            btnSalvar.IsEnabled = true;
            btnDinheiro.IsEnabled = false;
            btnCredito.IsEnabled = false;
            txtPagamento.IsEnabled = false;

        }

        private void BtnCredito_Click(object sender, RoutedEventArgs e)
        {
            cartao = 1;
            pagamento.Credito = true;
            txtNroCartao.IsEnabled = true;
            btnSalvar.IsEnabled = true;
            btnDinheiro.IsEnabled = false;
            btnDebito.IsEnabled = false;
            txtPagamento.IsEnabled = false;

        }

        private void BtnDinheiro_Click(object sender, RoutedEventArgs e)
        {
            txtPagamento.IsEnabled = true;
            btnPagar.IsEnabled = true;
            btnDebito.IsEnabled = false;
            btnCredito.IsEnabled = false;
        }

    }
}
