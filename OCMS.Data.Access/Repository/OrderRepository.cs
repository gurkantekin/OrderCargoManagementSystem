using OCMS.Data.Access.Entity;
using OCMS.Data.Access.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS.Data.Access.Repository
{
    public class OrderRepository : IOrderRepository<Order>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Order> AddAsync(Order @object)
        {
            @object.CreationDate = System.DateTime.Now;
            var obj = await _applicationDbContext.Order.AddAsync(@object);
            await _applicationDbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public IEnumerable<Order> GetAll()
        {
            return _applicationDbContext.Order;
        }

        public void Update(Order @object)
        {
            _applicationDbContext.Order.Update(@object);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Order @object)
        {
            _applicationDbContext.Remove(@object);
            _applicationDbContext.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return _applicationDbContext.Order.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
