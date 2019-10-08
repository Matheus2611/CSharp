using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace LocadoraWpf.Models
{
    [Table("DEVOLUCAO")]
    class Devolucao
    {
        [Key]
        public int IdDevolucao { get; set; }
        //public DateTime DataDevolucao { get; set; }
        public Cliente Cliente  { get; set; }
        public Carro Carro { get; set; }
        public Moto Moto { get; set; }
        public virtual Reserva Reserva { get; set; }
    }
}
