using LocadoraWpf.Models;
using System;

namespace LocadoraWpf.DAL
{
    class DevolucaoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static double CalcularValorDevolucao(Reserva reserva, DateTime devolvidoEm)
        {
            TimeSpan duration = devolvidoEm.Subtract(reserva.DataDevolucao);
            if (duration.TotalHours > 0.5 && duration.TotalHours <= 12.0)
            {
                double valorTotalPagamento = (reserva.ValorTotalReserva * 0.20) + reserva.ValorTotalReserva;
                return valorTotalPagamento;

            }
            else
            {
                double valorTotalPagamento = (reserva.ValorTotalReserva * 0.50) + reserva.ValorTotalReserva;
                return valorTotalPagamento;
            }
        }

        public static void SalvarDevolucaoPagamento(Reserva reserva, Pagamento pagamento)
        {
            reserva.Status = "PAGA";
            reserva.Cliente.PossuiReserva = "NAO";
            pagamento.Status = "PAGO";
            pagamento.DataHoraPagamento = DateTime.Now;
            if(reserva.Carro == null) { reserva.Moto.Status = "DISPONIVEL"; }
            if(reserva.Moto == null) { reserva.Carro.Status = "DISPONIVEL"; }
            //ctx.Devolucoes.Add(devolucao);
            ctx.Pagamentos.Add(pagamento);
            ctx.SaveChanges();
        }

    }
}
