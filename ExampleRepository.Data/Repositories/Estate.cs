using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleRepository.Data.Infraestrucure;
using RepositoryExample.Core;

namespace ExampleRepository.Data.Repositories
{
    public interface IEstate : IRepositoryBase<RepositoryExample.Core.Estate> {}

    public class Estate : RepositoryBase<RepositoryExample.Core.Estate>, IEstate
    {
        public Estate(DatabaseContext context) : base(context)
        { }
    }
}
