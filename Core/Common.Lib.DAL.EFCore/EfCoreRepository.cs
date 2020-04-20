using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using Common.Lib.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Common.Lib.DAL.EFCore
{
    public class EfCoreRepository<T> : IRepository<T> where T : Entity
    {

        DbContext DbContext { get; set; }

        public EfCoreRepository()
        {

        }

        public EfCoreRepository(DbContext context)
        {
            DbContext = context;
        }

        DbSet<T> DbSet
        {
            get
            {
                return DbContext.Set<T>();
            }
        }

        public IQueryable<T> QueryAll()
        {
            return DbSet.AsQueryable<T>();
        }

        public virtual T Find(int id)
        {
            return DbSet.Find(id);
        }

        public virtual OperationResult<T> Add(T entity)
        {
            var output = new OperationResult<T>()
            {
                Operation = CrudOperation.create
            };

            if (DbSet.Any(x => x.Id == entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Ojo!! Ya existe una entity con ese id");
            }

            if (output.IsSuccess)
            {

                DbSet.Add(entity);
                DbContext.SaveChanges();
                output.Entity = entity;
            }

            return output;

        }

        public virtual OperationResult<T> Update(T entity)
        {
            var output = new OperationResult<T>
            {
                Operation = CrudOperation.update
            };

            if (entity.Id == default(int))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede actualizar una entidad sin Id");
            }

            if (entity.Id != default(int) && DbSet.All(x => x.Id != entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No existe una entity con ese id");
            }

            if (output.IsSuccess)
            {
                DbSet.Update(entity);
                DbContext.SaveChanges();
                output.Entity = entity;
            }

            return output;
        }

        public virtual OperationResult<T> Delete(T entity)
        {
            var output = new OperationResult<T>
            {
                Operation = CrudOperation.delete
            };

            if (entity.Id == 0)
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede eliminar una entidad sin Id");
            }

            if (DbSet.All(x => x.Id != entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Esta entidad no se encuentra en la base de datos.");
            }

            if (output.IsSuccess)
            {
                DbSet.Remove(entity);
                DbContext.SaveChanges();
            }

            return output;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}