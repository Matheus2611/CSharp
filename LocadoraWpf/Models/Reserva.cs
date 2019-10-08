using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWpf.Models
{
    [Table("RESERVA")]
    class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double ValorTotalReserva { get; set; }
        public Cliente Cliente { get; set; }
        public Carro Carro { get; set; }
        public Moto Moto { get; set; }
        public string Status { get; set; }
        public int ClienteId { get; set; }
        public int CarroId { get; set; }
        public int MotoId { get; set; }

    }
}
