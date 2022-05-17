using OCMS.Data.Access.Entity;
using OCMS.Data.Access.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS.Data.Access.Repository
{
    public class CancellationRequestRepository : ICancellationRequestRepository<CancellationRequest>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CancellationRequestRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<CancellationRequest> AddAsync(CancellationRequest @object)
        {
            @object.CreationTime = System.DateTime.Now;
            @object.CreatorUserId = 1; //Sistemde user management sistemi olduğunu düşünürsek bu statil atamaya gerek kalmaz ancak bu case için bu şekilde yaptım
            var obj = await _applicationDbContext.CancellationRequest.AddAsync(@object);
            await _applicationDbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public IEnumerable<CancellationRequest> GetAll()
        {
            return _applicationDbContext.CancellationRequest;
        }

        public CancellationRequest GetOrderById(int orderId)
        {
            return _applicationDbContext.CancellationRequest.FirstOrDefault(x => x.OrderId.Equals(orderId));
        }

        public void Update(CancellationRequest @object)
        {
            @object.LastModificationTime = System.DateTime.Now;
            @object.LastModifierUserId = 1; 
            _applicationDbContext.CancellationRequest.Update(@object);
            _applicationDbContext.SaveChanges();
        }
    }
}