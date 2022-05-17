using System.Collections.Generic;
using System.Threading.Tasks;

namespace OCMS.Data.Access.Interface
{
    public interface IProductRepository<T>
    {
        public Task<T> AddAsync(T @object);
        public IEnumerable<T> GetAll();
        public T GetByProductCode(string productCode);
        public void Update(T @object);
        public void Delete(T @object);
    }
}
