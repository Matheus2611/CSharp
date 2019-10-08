using LocadoraWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWpf.DAL
{
    class PagamentoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static double Pagamento(Pagamento pg)
        {
            double result = 0;

            if (pg.ValorPagamento > pg.ValorTotalReserva)
            {
                result = pg.ValorPagamento - pg.ValorTotalReserva;
            }
            else if (pg.ValorPagamento < pg.ValorTotalReserva)
            {
                result = pg.ValorTotalReserva - pg.ValorPagamento;
            }
            else if(pg.ValorPagamento > pg.ValorTotalReserva)
            {
                result = pg.ValorPagamento - pg.ValorTotalReserva;
            }
            else if(pg.ValorTotalReserva == pg.ValorPagamento)
            {
                pg.ValorTotalReserva = pg.ValorTotalReserva - pg.ValorPagamento;
                return pg.ValorTotalReserva;
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
