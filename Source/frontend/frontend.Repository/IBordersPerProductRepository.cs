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
        Task<IEnumerable<BorderPerProduct>> GetAllBordersPerProducts();
        Task<BorderPerProduct> GetBordersPerProductById(int id);
        void AddBordersPerProduct(BorderPerProduct bordersPerProduct);
        void UpdateBordersPerProduct(BorderPerProduct bordersPerProduct);
        void DeleteBordersPerProduct(int id);
    }
}
