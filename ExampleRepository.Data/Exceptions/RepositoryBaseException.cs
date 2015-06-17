using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRepository.Data.Exceptions
{
    [Serializable]
    class RepositoryBaseException : Exception
    {
        public static string DEFAULTMESSAGEEXCEPTION 
        { 
            get
            {
                return "Ocurrio un Error Inesperado. Consulte con el Administrador.";
            } 
        }

        public RepositoryBaseException() { }

        public RepositoryBaseException(string message) : base(message)
        { }
    }
}
