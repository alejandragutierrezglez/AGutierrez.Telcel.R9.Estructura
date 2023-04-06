using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public List<object> Empleados { get; set; }
        public Negocio.Puesto Puesto { get; set; }
        public Negocio.Departamento Departamento { get; set; }




        public static Negocio.Result GetAllEF(Negocio.Empleado empleado)
        {
            Negocio.Result result = new Negocio.Result();
            {
                try
                {
                    using (AccesoDatos.AGutierrezEstructuraEntities1 context = new AccesoDatos.AGutierrezEstructuraEntities1())
                    {
                        var query = context.EmpleadoGetAll(empleado.Nombre).ToList();

                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var resultEmpleado in query)
                            {
                                empleado = new Negocio.Empleado();
                                empleado.EmpleadoID = resultEmpleado.EmpleadoID;
                                empleado.Nombre = resultEmpleado.Nombre;

                                empleado.Puesto = new Negocio.Puesto();
                                empleado.Puesto.PuestoID = resultEmpleado.PuestoID.Value;

                                empleado.Departamento = new Negocio.Departamento();
                                empleado.Departamento.DepartamentoID= resultEmpleado.DepartamentoID.Value;


                               result.Objects.Add(empleado);
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

        public static Negocio.Result DeleteEF(int EmpleadoID)
        {
            Negocio.Result result = new Negocio.Result();
            try
            {
                using (AccesoDatos.AGutierrezEstructuraEntities1 context = new AccesoDatos.AGutierrezEstructuraEntities1())
                {
                    var query = context.EmpleadoDelete(EmpleadoID);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Negocio.Result AddEF(Negocio.Empleado empleado)
        {
            using (AccesoDatos.AGutierrezEstructuraEntities1 context = new AccesoDatos.AGutierrezEstructuraEntities1())
            {
                Negocio.Result result = new Negocio.Result();
                try
                {

                    var query = context.EmpleadoAdd(empleado.Nombre, empleado.Puesto.PuestoID, empleado.Departamento.DepartamentoID);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                catch (Exception ex)
                {

                    result.ErrorMessage = ex.Message;
                    result.Ex = ex;
                    result.Correct = false;
                }
                return result;

            }
        }   



    }
}
