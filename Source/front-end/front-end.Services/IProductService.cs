using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public interface IProductService
    {
        List<Product> All();
        Product Find(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
