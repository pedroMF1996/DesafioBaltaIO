using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBaltaIO.Domain.Entidades
{
    public class Localidade
    {
        public int Codigo { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
    }
}
