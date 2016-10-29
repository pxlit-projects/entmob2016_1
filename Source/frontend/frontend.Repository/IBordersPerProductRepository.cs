using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface IBordersPerProductRepository
    {
        Task<List<BorderPerProduct>> GetAllBordersPerProducts();
        Task<BorderPerProduct> GetBordersPerProductById(int product_id, int cargo_id);
        void AddBordersPerProduct(BorderPerProduct bordersPerProduct);
    }
}
