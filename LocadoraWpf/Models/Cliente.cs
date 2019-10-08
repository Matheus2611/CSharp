using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraWpf.Models
{
    [Table("CLIENTE")]
    class Cliente
    {
        public Cliente()
        {
            Endereco = new Endereco();
            Reserva = new List<Reserva>();
            Devolucao = new List<Devolucao>();
            Pagamento = new List<Pagamento>();
        }
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Cnh { get; set; }
        public string cep { get; set; }
        public string Telefone { get; set; }
        public string PossuiReserva { get; set; } 
        public Endereco Endereco { get; set; }
        public string CategoriaCnh { get; set; }
        public List<Reserva> Reserva { get; set; }
        public List<Devolucao> Devolucao { get; set; }
        public List<Pagamento> Pagamento { get; set; }
        public string Status { get; set; }
        public int MotoId { get; set; }
        public int CarroId { get; set; }
    }
}
