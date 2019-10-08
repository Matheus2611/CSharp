using LocadoraWpf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LocadoraWpf.DAL
{
    class ReservaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Reserva> ListarReservasPendente() => ctx.Reservas.Where(x => x.Status.Equals("PENDENTE")).ToList();

        public static List<Reserva> ListarReservas() => ctx.Reservas.ToList();

        public static void SalvarReserva(Reserva reserva)
        {
            ctx.Reservas.Add(reserva);
            ctx.SaveChanges();
        }

        public static bool DefineVeiculoParaSalvarReserva(Cliente cliente, Reserva reserva, Carro carro, Moto moto)
        {
            if (moto != null)
            {
                cliente.PossuiReserva = "SIM";
                reserva.MotoId = moto.IdVeiculo;
                cliente.CarroId = 0;
                reserva.ValorTotalReserva = CalculaValorReserva(reserva, moto);
                reserva.Cliente = cliente;
                moto.Status = "RESERVADO";
                reserva.Moto = moto;
                reserva.Status = "PENDENTE";
                cliente.MotoId = moto.IdVeiculo;
                reserva.ClienteId = cliente.IdCliente;
                SalvarReserva(reserva);
                return true;
            }
            if (carro != null)
            {
                cliente.PossuiReserva = "SIM";
                reserva.CarroId = carro.IdVeiculo;
                cliente.MotoId = 0;
                carro.Status = "RESERVADO";
                reserva.ValorTotalReserva = CalculaValorReserva(reserva, carro);
                reserva.Cliente = cliente;
                reserva.Carro = carro;
                reserva.Status = "PENDENTE";
                cliente.CarroId = carro.IdVeiculo;
                reserva.ClienteId = cliente.IdCliente;
                SalvarReserva(reserva);
                return true;
            }
            return false;
        }

        public static double CalculaValorReserva(Reserva reserva, Veiculo veiculo)
        {
            TimeSpan duration = reserva.DataReserva.Subtract(reserva.DataDevolucao);

            if (duration.Hours < 0 || duration.Days < 0)
            {
                duration = reserva.DataDevolucao.Subtract(reserva.DataReserva);
            }

            if (duration.TotalHours <= 12.0)
            {
                return reserva.ValorTotalReserva = veiculo.ValorPorHora * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                return reserva.ValorTotalReserva = veiculo.ValorPorDia * Math.Ceiling(duration.TotalDays);
            }
        }

        public static void UpdateReserva(Reserva reserva)
        {
            ctx.Entry(reserva).State = EntityState.Modified;

            ctx.SaveChanges();
        }

        public static Reserva GetReserva(Reserva reserva)
        {
            var result = ctx.Reservas.FirstOrDefault(x => x.IdReserva.Equals(reserva.IdReserva));

            return result;
        }

        public static List<Reserva> GetReservaCarro(string parameter, int id)
        {
            var result = ctx.Reservas.Include(x => x.Cliente).Where(x => x.Cliente.Cpf.Equals(parameter))
                .Include(x => x.Carro).Where(x => x.Carro.IdVeiculo.Equals(id)).Where(x => x.Status.Equals("APROVADO")).ToList();

            return result;
        }

        public static List<Reserva> GetReservaMoto(string parameter, int id)
        {
            var result = ctx.Reservas.Include(x => x.Cliente).Where(x => x.Cliente.Cpf.Equals(parameter)).Include(x => x.Moto)
                .Where(x => x.Moto.IdVeiculo.Equals(id)).Where(x => x.Status.Equals("APROVADO")).ToList();

            return result;
        }
    }
}
