using System.Collections.Generic;
using System.Threading.Tasks;

namespace OCMS.Data.Access.Interface
{
    public interface ICancellationRequestRepository<T>
    {
        public Task<T> AddAsync(T @object);

        public IEnumerable<T> GetAll();
        public T GetOrderById(int orderId);
        public void Update(T @object);
    }
}
