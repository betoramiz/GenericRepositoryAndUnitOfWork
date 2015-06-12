using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRepository.Data.Infraestrucure
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
