using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practicing_For_Work.Application.Contracts
{
    public class ApplicationResult<T>
    {
        private static readonly ApplicationResult<T> _success = new ApplicationResult<T> { Succeeded = true };
        private List<ApplicationError> _errors = new List<ApplicationError>();


        public bool Succeeded { get; protected set; }

        public IEnumerable<ApplicationError> Errors => _errors;

        public T Data { get; set; }

        public static ApplicationResult<T> Success => _success;

        public static ApplicationResult<T> Failed(params ApplicationError[] errors)
        {
            var result = new ApplicationResult<T> { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }
        public string FailedMessage()
        {
            return string.Join(", ", Errors.Select(x => x.Description));
        }
    }
}
