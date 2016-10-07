using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public interface IBordersPerProductRepository
    {
        Task<IEnumerable<BordersPerProduct>> GetAllBordersPerProducts();
        Task<BordersPerProduct> GetBordersPerProductById(int id);
        void AddBordersPerProduct(BordersPerProduct bordersPerProduct);
        void UpdateBordersPerProduct(BordersPerProduct bordersPerProduct);
        void DeleteBordersPerProduct(int id);
    }
}
