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
        Task<IEnumerable<BordersPerProduct>> GetAllBordersPerProducts();
        Task<BordersPerProduct> GetBordersPerProductById(int id);
        void AddBordersPerProduct(BordersPerProduct bordersPerProduct);
        void UpdateBordersPerProduct(BordersPerProduct bordersPerProduct);
        void DeleteBordersPerProduct(int id);
    }
}
