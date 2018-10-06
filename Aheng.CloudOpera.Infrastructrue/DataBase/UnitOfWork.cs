using Aheng.CloudOpera.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aheng.CloudOpera.Infrastructrue.DataBase
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly OperaContext _operaContext;

        public async Task<bool> CompleteWorkAsync()
        {
            return await _operaContext.SaveChangesAsync() > 0;
        }

        public bool Save()
        {
            return _operaContext.SaveChanges() > 0;
        }
    }
}
