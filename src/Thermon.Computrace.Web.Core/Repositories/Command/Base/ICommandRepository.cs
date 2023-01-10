using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Core.Repositories.Command.Base
{    
    public interface ICommandRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
