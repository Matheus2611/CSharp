using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using System;
using System.Windows;
using System.Windows.Controls;


namespace LocadoraWpf.Views.Controls
{
    /// <summary>
    /// Interaction logic for usAprovaReservaCarro.xaml
    /// </summary>
    public partial class usAprovaReservaCarro : UserControl
    {
        public usAprovaReservaCarro()
        {
            InitializeComponent();
            ListarReservaPendente();
        }

        public void ListarReservaPendente()
        {
            ListarReservasPendente.ItemsSource = ReservaDAO.ListarReservasPendente();
            ListarReservasPendente.CanUserAddRows = false;
            ListarReservasPendente.IsReadOnly = true;
            ListarReservasPendente.AutoGenerateColumns = false;
            ListarReservasPendente.CanUserDeleteRows = false;
        }

        private void BtnAprovar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reserva reserva = ListarReservasPendente.SelectedItem as Reserva;
                if (reserva == null)
                {
                    MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                else
                {
                    reserva.Status = "APROVADO";
                    ReservaDAO.UpdateReserva(reserva);
                    MessageBox.Show("A Reserva foi Aprovada!!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    ListarReservaPendente();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnCancelarReserva_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reserva reserva = ListarReservasPendente.SelectedItem as Reserva;

                #region Instancias
                Cliente cliente = new Cliente();
                Carro carro = new Carro();
                Moto moto = new Moto();
                cliente.IdCliente = reserva.ClienteId;
                cliente = ClienteDAO.GetId(cliente);
                carro.IdVeiculo = reserva.CarroId;
                moto.IdVeiculo = reserva.MotoId;
                #endregion

                if (reserva == null)
                {
                    MessageBox.Show("Selecione um registro!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Deseja realmente cancelar essa reserva ?", "LocadoraWPF",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    { return; }
                    if (carro.IdVeiculo == 0)
                    {
                        moto = VeiculoDAO.GetIdMoto(moto);
                        moto.Status = "DISPONIVEL";
                        reserva.Moto = moto;
                    }
                    if (moto.IdVeiculo == 0)
                    {
                        
                        carro = VeiculoDAO.GetIdCarro(carro);
                        carro.Status = "DISPONIVEL";
                        reserva.Carro = carro;
                    }
                    cliente.PossuiReserva = "NAO";
                    reserva.Cliente = cliente;
                    reserva.Status = "CANCELADA";
                    ReservaDAO.UpdateReserva(reserva);
                    MessageBox.Show("A Reserva do Cliente: " + cliente.Nome + " foi cancelada!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    ListarReservaPendente();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
