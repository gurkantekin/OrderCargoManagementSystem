using OCMS.Data.Access.Entity;
using OCMS.Data.Access.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCMS.Data.Access.Repository
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Product> AddAsync(Product @object)
        {
            var obj = await _applicationDbContext.Product.AddAsync(@object);
            await _applicationDbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public IEnumerable<Product> GetAll()
        {
            return _applicationDbContext.Product;
        }

        public void Update(Product @object)
        {
            _applicationDbContext.Product.Update(@object);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Product @object)
        {
            _applicationDbContext.Remove(@object);
            _applicationDbContext.SaveChanges();
        }

        public Product GetByProductCode(string productCode)
        {
            return _applicationDbContext.Product.FirstOrDefault(x => x.ProductCode.Equals(productCode));
        }
    }
}
