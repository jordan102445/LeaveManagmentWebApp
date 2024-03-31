
using LeaveManagmentWebApp;
namespace LeaveManagmentWebApp.Contracts
{
    public interface IGenericRepository<T> where T : class// generic allow facility in more then one class // for all like leaveTypes(separete)
                                                                    // for leaveAllocation(separete)
                                                                  // generic programming is template T 
    {

        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync(); // T vrakja class

        Task<T> AddAsync(T entity); 

        Task<bool> Exists(int id);

        Task DeleteAsync(int id);

        Task UpdateAsync(T entity);


    }
}
