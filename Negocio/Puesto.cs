using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Puesto
    {
        public int PuestoID { get; set; }
        public string Descripcion { get; set; }
        public List<object> Puestos { get; set; }
        public static Negocio.Result GetAllEF()
        {
            Negocio.Result result = new Negocio.Result();
            {
                try
                {
                    using (AccesoDatos.AGutierrezEstructuraEntities1 context = new AccesoDatos.AGutierrezEstructuraEntities1())
                    {
                        var query = context.PuestoGetAll().ToList();

                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var resultPuesto in query)
                            {
                                Negocio.Puesto puesto = new Negocio.Puesto();
                                puesto.PuestoID = resultPuesto.PuestoID;
                                puesto.Descripcion = resultPuesto.Descripcion;


                                result.Objects.Add(puesto);
                            }
                            result.Correct = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Ex = ex;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }
        }
    }
}
