using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWpf.Models
{
    [Table("PAGAMENTO")]
    class Pagamento
    {
        [Key]
        public int IdPagamento { get; set; }
        public bool? Credito { get; set; }
        public bool? Debito { get; set; }
        public bool? Dinheiro { get; set; }
        public string NroCartao { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataHoraPagamento { get; set; }
        public string Status { get; set; }
        public double ValorTotalReserva { get; set; }
        public double ValorPagamento { get; set; }
        public double ValorTroco { get; set; }
    }
}
