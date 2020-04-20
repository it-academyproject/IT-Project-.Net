using Common.Lib.Core;
using Common.Lib.Infrastructure.Enums;

namespace Common.Lib.Infrastructure
{
    public class OperationResult<T> where T : Entity
    {
        public ValidationResult Validation { get; set; } = new ValidationResult();
        public bool IsSuccess
        {
            get
            {
                return Validation.IsSuccess;
            }
            set
            {
                Validation.IsSuccess = value;
            }
        }
        public string AllErrors
        {
            get
            {
                return Validation.AllErrors;
            }
        }
        public T Entity { get; set; }
        public CrudOperation Operation { get; set; }

    }
}
