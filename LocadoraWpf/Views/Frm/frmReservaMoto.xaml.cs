using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LocadoraWpf.Views.Frm
{
    /// <summary>
    /// Interaction logic for frmReservaMoto.xaml
    /// </summary>
    public partial class frmReservaMoto : Window
    {

        public string ParameterCliente { get; set; }
        public string ParameterCarro { get; set; }
        public frmReservaMoto(string cpf, string placa)
        {
            ParameterCliente = cpf;
            ParameterCarro = placa;
            InitializeComponent();
        }

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Cliente cliente = new Cliente();
                Moto moto = new Moto();
                Reserva reserva = new Reserva();
                cliente.Cpf = ParameterCliente;
                moto.Placa = ParameterCarro;
                cliente = ClienteDAO.Get(cliente);
                moto = (Moto)VeiculoDAO.Get(null, moto);

                DateTime? dtR = dtReserva.SelectedDate;
                DateTime? dtD = dtDevolucao.SelectedDate;

                if (dtDevolucao.SelectedDate == null || dtReserva.SelectedDate == null)
                {
                    MessageBox.Show("Preencha os Campos em branco!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                ComboBoxItem itemR = (ComboBoxItem)cboHoraReserva.SelectedItem;
                ComboBoxItem itemD = (ComboBoxItem)cboHoraDevolucao.SelectedItem;

                if (cboHoraDevolucao.SelectedItem == null || cboHoraReserva.SelectedItem == null)
                {
                    MessageBox.Show("Preencha os Campos em branco!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                int horaDevolucao = Convert.ToInt32(itemD.Content.ToString().Replace(":00", ""));
                int horaReserva = Convert.ToInt32(itemR.Content.ToString().Replace(":00", ""));

                reserva.DataReserva = Convert.ToDateTime(dtR.Value.AddHours(horaReserva));
                reserva.DataDevolucao = Convert.ToDateTime(dtD.Value.AddHours(horaDevolucao));

                if (string.IsNullOrWhiteSpace(cboHoraDevolucao.Text) || string.IsNullOrWhiteSpace(cboHoraReserva.Text)
                    || string.IsNullOrWhiteSpace(dtDevolucao.Text) || string.IsNullOrWhiteSpace(dtReserva.Text))
                {
                    MessageBox.Show("Preencha os Campos em branco!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (reserva.DataReserva.Day > reserva.DataDevolucao.Day &&
                    reserva.DataReserva.DayOfWeek > reserva.DataDevolucao.DayOfWeek &&
                    reserva.DataReserva.DayOfYear > reserva.DataDevolucao.DayOfYear)
                {
                    MessageBox.Show("Data de devolução não pode ser menor que a data de reserva!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (ReservaDAO.DefineVeiculoParaSalvarReserva(cliente, reserva, null, moto))
                {
                    MessageBox.Show("A sua reserva foi registrada! \n" +
                        "Aguarde a aprovação do Administrador! \n" +
                        "O Valor da reserva ficou: " + reserva.ValorTotalReserva.ToString("C2") + "\n" +
                        "\nPagamento será realizado na hora da devolução do veiculo!", "LocadoraWPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Algo deu errado", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); return; }
        }
    }
}
