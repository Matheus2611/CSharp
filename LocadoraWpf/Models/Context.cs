using System.Data.Entity;

namespace LocadoraWpf.Models
{
    class Context : DbContext
    {
        public Context() : base("DbLocadora") { }
        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Devolucao> Devolucoes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}
