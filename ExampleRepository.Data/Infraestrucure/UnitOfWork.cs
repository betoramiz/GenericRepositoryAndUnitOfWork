using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryExample.Core;

namespace ExampleRepository.Data.Infraestrucure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext context)
        {
            _dbContext = context;
        }

        #region repositories
        private RepositoryBase<Estate> estateRepository;
        public RepositoryBase<Estate> EstateRepository
        {
            get
            {
                return estateRepository ?? (estateRepository = new RepositoryBase<Estate>(_dbContext));
            }
        }

        private RepositoryBase<Town> townRepository;
        public RepositoryBase<Town> TownRepository
        {
            get
            {
                return townRepository ?? (townRepository = new RepositoryBase<Town>(_dbContext));
            }
        }
        #endregion

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
