using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleRepository.Data.Infraestrucure;
using RepositoryExample.Core;

namespace ExampleRepository.Data.Repositories
{
    public interface ITown : IRepositoryBase<RepositoryExample.Core.Town> 
    { 
    }

    public class Town : RepositoryBase<RepositoryExample.Core.Town>, ITown
    {
        public Town(DatabaseContext context) : base(context)
        {
        }
    }
}
