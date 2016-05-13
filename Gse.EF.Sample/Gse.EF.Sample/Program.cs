using Gse.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gse.EF.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            GseDbContext _db = new GseDbContext();

            var query = _db.Empresas.Where(e => e.Cif == "XIMEN");

            foreach (Empresa item in query) {
                Console.WriteLine(String.Format("Empresa: {0}, Cif: {1}", item.Id, item.Cif));
            }
        }
    }
}
