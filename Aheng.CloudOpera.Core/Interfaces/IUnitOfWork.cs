using System.Threading.Tasks;

namespace Aheng.CloudOpera.Core.Interfaces
{
    public interface IUnitOfWork
    {
        bool Save();
        Task<bool> CompleteWorkAsync();
    }
}
