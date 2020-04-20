using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using Common.Lib.Infrastructure.Enums;
using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Common.Lib.Core
{
    public abstract class Entity
    {
        public int Id { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; set; }

        public virtual ValidationResult Validate()
        {
            var output = new ValidationResult();
            return output;
        }

        public static IDependencyContainer DepCon { get; set; }

        public virtual OperationResult<T> Save<T>() where T : Entity
        {
            var output = new OperationResult<T>()
            {
                Operation = CrudOperation.create
            };

            this.Validation = Validate();

            if (Validation.IsSuccess)
            {
                var repo = Entity.DepCon.Resolve<IRepository<T>>();

                if (this.Id == default(int))
                    repo.Add(this as T);
                
                else
                    repo.Update(this as T);
            }

            output.Validation = this.Validation;

            return output;
        }

        public virtual OperationResult<T> Delete<T>() where T : Entity
        {
            var output = new OperationResult<T>()
            {
                Operation = CrudOperation.delete
            };

            var repo = Entity.DepCon.Resolve<IRepository<T>>();
            repo.Delete(this as T);

            return output;
        }

    }
}
