using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRepository.Data.Exceptions
{
    class NotSavedException : RepositoryBaseException
    {
        private const string Message = "No se pudo guardar en la base de datos.";

        public NotSavedException()
            : base(DEFAULTMESSAGEEXCEPTION)
        { }

        public NotSavedException(string message) : base(message ?? Message)
        { }
    }
}
