using LocadoraWpf.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LocadoraWpf.DAL
{
    class ClienteDAO
    {

        private static Context ctx = SingletonContext.GetInstance();

        public static List<Cliente> ListarCliente() => ctx.Clientes.ToList();

        public ClienteDAO()
        {

            foreach (var item in ListarCliente())
            {
                Endereco endereco = new Endereco();
                new Cliente
                {
                    Nome = item.Nome,
                    Rg = item.Rg,
                    Cpf = item.Cpf
                };
            }

        }

        public static bool CadastrarCliente(Cliente cliente)
        {
            if (Get(cliente) != null)
            {
                return false;
            }
            cliente.PossuiReserva = "NAO";
            ctx.Clientes.Add(cliente);
            ctx.SaveChanges();
            return true;
        }

        public static bool AutenticarLogin(Cliente cliente)
        {
            var result = ctx.Clientes.FirstOrDefault(x => x.Cpf.Equals(cliente.Cpf) && x.Senha.Equals(cliente.Senha));
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public static bool ConfereStatus(Cliente cliente)
        {
            var result = ctx.Clientes.FirstOrDefault(x => x.Cpf.Equals(cliente.Cpf) && x.Status.Equals("CANCELADO"));

            if (result == null)
                return true;
            else
                return false;
        }

        public static Cliente Get(Cliente cliente)
        {
            var result = ctx.Clientes.Where(x => x.Cpf.Equals(cliente.Cpf)).FirstOrDefault();

            return result;
        }

        public static void AlterarDadosCliente(Cliente cliente)
        {
            ctx.Entry(cliente).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static bool RemoverCliente(Cliente cliente) // cliente remove sua conta
        {
            cliente = Get(cliente);
            if(cliente.PossuiReserva.Equals("SIM")) { return false; }
            cliente.Status = "CANCELADO";
            AlterarDadosCliente(cliente);
            return true;
        }

        public static List<Cliente> BuscarCliente(string nome)
        {
            var result = ctx.Clientes.Where(x => x.Nome.Contains(nome)).ToList();

            return result;
        }

        public static Cliente GetId(Cliente cliente)
        {
            var result = ctx.Clientes.Where(x => x.IdCliente.Equals(cliente.IdCliente)).FirstOrDefault();

            return result;
        }

    }
}
