using Gse.EF.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gse.EF.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            GseDbContext _db;
            CultureInfo ci = CultureInfo.InvariantCulture;

            //var query = _db.Empresas.Where(e => e.Cif == "XIMEN");
            int countEntidades = 0;
            Console.WriteLine(string.Format("Start time: {0}", DateTime.Now.ToString("hh:mm:ss.ff", ci)));

            using (_db = new GseDbContext())
            {
                //
                var entidadEmpresaModel = from _entidad in _db.Entidades
                        join _empresa in _db.Empresas on _entidad.Id equals _empresa.EntidadId 
                        into entidadEmpresas
                        select new { _entidad, entidadEmpresas };
                var lstEntidadEmpresas = entidadEmpresaModel.ToList();
                countEntidades = lstEntidadEmpresas.Count();
                // Console.WriteLine("Obtain all entities -empresa-.-entidad- from database -Gse-");
                // var empresas = _db.Empresas.Include("Entidad").ToList();
                //Console.WriteLine("Obtain all entities -ENTIDAD-.-EMPRESA- from database -Gse-");
                //var entidades = _db.Entidades.Include("Empresas").ToList();
                //countEntidades = entidades.Count;
            }
            Console.WriteLine(string.Format("End time: {0}", DateTime.Now.ToString("hh:mm:ss.ff", ci)));
            Console.WriteLine("");
            Console.WriteLine("Count Entidades: {0}", countEntidades);
            //Console.WriteLine("Count Entidades: {0}", countEntidades);
            //Console.WriteLine("Obtain all entities -entidades- from database -Gse-");

            //var entidades = _db.Entidades.AsNoTracking().ToList();


            //foreach (Empresa item in query) {
            //    Console.WriteLine(String.Format("Empresa: {0}, Cif: {1}", item.Id, item.Cif));
            //}
            Console.WriteLine("");

            #region Show All Empresas
            //int countEmpresas = empresas.Count();
            //Console.WriteLine(string.Format("Count -empresas-: {0}", countEmpresas));

            //Console.WriteLine("");

            //for (int i = 0; i < countEmpresas; i++)
            //{
            //    Console.WriteLine(String.Format("Empresa: {0}, Cif: {1}, Tipo: {2}", empresas[i].Id, empresas[i].Cif, empresas[i].Tipo));
            //}
            #endregion
            

            Console.WriteLine("Press enter to continue."); Console.Read();
        }
    }
}
