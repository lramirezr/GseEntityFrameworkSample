using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gse.EF.Data
{
    public class Empresa
    {
        public decimal Id { get; set; }
        public string Cif { get; set; }
        public string Tipo { get; set; }
        public decimal? EntidadId { get; set; }
        // [ForeignKey("EntidadId")]
        public virtual Entidad Entidad { get; set; }
    }
}
