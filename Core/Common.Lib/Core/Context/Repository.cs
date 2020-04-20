
using Common.Lib.Infrastructure;
using Common.Lib.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Lib.Core.Context
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private static Dictionary<int, T> DbSet { get; set; } = new Dictionary<int, T>();

        public IQueryable<T> QueryAll()
        {
            return DbSet.Values.AsQueryable<T>();
        }

        public T Find(int id)
        {
            return DbSet[id];
        }

        public virtual OperationResult<T> Add(T entity)
        {
            var output = new OperationResult<T>()
            {
                Operation = CrudOperation.create
            };

            if (entity.Id == default(int))
            {
                //Pensar un bucle para no repetir id
                var randomGen = new Random();
                entity.Id = randomGen.Next(1000);
            }

            if (DbSet.ContainsKey(entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Ya existe una entity con ese id");
            }

            if (output.IsSuccess)
            {
                DbSet.Add(entity.Id, entity);
            }

            return output;
        }

        public virtual OperationResult<T> Update(T entity)
        {
            var output = new OperationResult<T>()
            {
                Operation = CrudOperation.update
            };

            if (entity.Id == default(int))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede actualizar una entidad sin Id");
            }

            if (entity.Id != default(int) && !DbSet.ContainsKey(entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No existe una entity con ese id");
            }

            if (output.IsSuccess)
            {
                DbSet[entity.Id] = entity;
            }

            return output;
        }

        public OperationResult<T> Delete(T entity)
        {
            var output = new OperationResult<T>()
            {
                Operation = CrudOperation.delete
            };

            if (entity.Id == default(int))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede eliminar una entidad sin Id");
            }

            if (!DbSet.ContainsKey(entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Esta entidad no se encuentra en la base de datos.");
            }

            return output;
        }

        public void Dispose()
        {

        }
    }
}
