using LocadoraWpf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWpf.DAL
{
    class VeiculoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static List<Carro> ListarAllCarro() => ctx.Carros.ToList();
        public static List<Moto> ListarAllMoto() => ctx.Motos.ToList();
        public static List<Carro> ListarCarro() => ctx.Carros.Where(x => x.Status.Equals("DISPONIVEL")).ToList();
        public static List<Moto> ListarMoto() => ctx.Motos.Where(x => x.Status.Equals("DISPONIVEL")).ToList();

        public static bool CadastrarVeiculo(Carro carro, Moto moto)
        {
            if (carro != null)
            {
                if (Get(carro, null) != null)
                {
                    return false;
                }
                ctx.Carros.Add(carro);
                ctx.SaveChanges();
                return true;
            }
            if (moto != null)
            {
                if (Get(null, moto) != null)
                {
                    return false;
                }
                ctx.Motos.Add(moto);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Veiculo Get(Carro carro, Moto moto)
        {

            if (carro != null)
            {
                var result = ctx.Carros.FirstOrDefault(x => x.Placa.Equals(carro.Placa));

                return result;
            }
            else
            {
                var result = ctx.Motos.FirstOrDefault(x => x.Placa.Equals(moto.Placa));

                return result;
            }
        }

        public static void AlterarDadosVeiculo(Carro carro, Moto moto)
        {
            if (carro != null) { ctx.Entry(carro).State = EntityState.Modified; }
            if (moto != null) { ctx.Entry(moto).State = EntityState.Modified; }
            ctx.SaveChanges();
        }

        public static void RemoverVeiculo(Carro carro, Moto moto)
        {
            if (carro != null)
            {
                carro.Status = "CANCELADO";
                AlterarDadosVeiculo(carro, null);
            }
            if (moto != null)
            {
                moto.Status = "CANCELADO";
                AlterarDadosVeiculo(null, moto);
            }
        }

        public static List<Carro> PesquisarCarro(string placa)
        {
            var result = ctx.Carros.Where(x => x.Placa.Equals(placa)).ToList();

            return result;
        }

        public static List<Moto> PesquisarMoto(string placa)
        {
            var result = ctx.Motos.Where(x => x.Placa.Equals(placa)).ToList();

            return result;
        }

        public static Carro GetIdCarro(Carro carro)
        {
            var result = ctx.Carros.FirstOrDefault(x => x.IdVeiculo.Equals(carro.IdVeiculo));

            return result;
        }

        public static Moto GetIdMoto(Moto moto)
        {
            var result = ctx.Motos.FirstOrDefault(x => x.IdVeiculo.Equals(moto.IdVeiculo));

            return result;
        }

    }
 


}

