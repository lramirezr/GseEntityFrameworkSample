using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gse.EF.Data
{
    public class Entidad
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }

        public Entidad()
        {
            Empresas = new List<Empresa>();
        }
    }
}
