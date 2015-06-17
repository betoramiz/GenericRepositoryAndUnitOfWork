using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRepository.Data.Exceptions
{
    class NotFoundException : RepositoryBaseException
    {
        private const string Message = "No se encontro el recurso.";

        public NotFoundException()
            :base(DEFAULTMESSAGEEXCEPTION)
        { }

        public NotFoundException(string message)
            :base(message ?? Message)
        { }
    }
}
