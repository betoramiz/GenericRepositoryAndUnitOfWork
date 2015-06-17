using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRepository.Data.Exceptions
{
    class NotDeletedException : RepositoryBaseException
    {
        private const string Message = "";

        public NotDeletedException () 
            : base(DEFAULTMESSAGEEXCEPTION)
        { }

        public NotDeletedException(string message) 
            : base(message ?? Message)
        { }
    }
}
