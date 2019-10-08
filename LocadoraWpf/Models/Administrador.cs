using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWpf.Models
{
    class Administrador
    {
        public Administrador()
        {
            Login = "ADM";
            Senha = "ADM";
        }
        public string Login { get; set; }
        public string Senha { get; set; }
        
    }
}
