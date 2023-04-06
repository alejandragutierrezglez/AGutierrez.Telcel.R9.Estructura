using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }
        public string Descripcion { get; set; }
        public List<object> Departamentos { get; set; }

        public static Negocio.Result GetAllEF()
        {
            Negocio.Result result = new Negocio.Result();
            {
                try
                {
                    using (AccesoDatos.AGutierrezEstructuraEntities1 context = new AccesoDatos.AGutierrezEstructuraEntities1())
                    {
                        var query = context.DepartamentoGetAll().ToList();

                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var resultDepartamento in query)
                            {
                                Negocio.Departamento departamento = new Negocio.Departamento();
                                departamento.DepartamentoID = resultDepartamento.DepartamentoID;
                                departamento.Descripcion = resultDepartamento.Descripcion;


                                result.Objects.Add(departamento);
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
