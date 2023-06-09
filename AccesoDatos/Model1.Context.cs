﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AGutierrezEstructuraEntities1 : DbContext
    {
        public AGutierrezEstructuraEntities1()
            : base("name=AGutierrezEstructuraEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<DepartamentoGetAll_Result> DepartamentoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DepartamentoGetAll_Result>("DepartamentoGetAll");
        }
    
        public virtual int EmpleadoAdd(string nombre, Nullable<int> puestoID, Nullable<int> departamentoID)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var puestoIDParameter = puestoID.HasValue ?
                new ObjectParameter("PuestoID", puestoID) :
                new ObjectParameter("PuestoID", typeof(int));
    
            var departamentoIDParameter = departamentoID.HasValue ?
                new ObjectParameter("DepartamentoID", departamentoID) :
                new ObjectParameter("DepartamentoID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoAdd", nombreParameter, puestoIDParameter, departamentoIDParameter);
        }
    
        public virtual ObjectResult<EmpleadoByNombreCoincidente_Result> EmpleadoByNombreCoincidente(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoByNombreCoincidente_Result>("EmpleadoByNombreCoincidente", nombreParameter);
        }
    
        public virtual int EmpleadoDelete(Nullable<int> empleadoID)
        {
            var empleadoIDParameter = empleadoID.HasValue ?
                new ObjectParameter("EmpleadoID", empleadoID) :
                new ObjectParameter("EmpleadoID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoDelete", empleadoIDParameter);
        }
    
        public virtual ObjectResult<PuestoGetAll_Result> PuestoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PuestoGetAll_Result>("PuestoGetAll");
        }
    
        public virtual ObjectResult<EmpleadoGetAll_Result> EmpleadoGetAll(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetAll_Result>("EmpleadoGetAll", nombreParameter);
        }
    }
}
