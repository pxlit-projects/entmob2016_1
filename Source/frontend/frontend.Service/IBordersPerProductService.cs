using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface IBordersPerProductService
    {
        List<BordersPerProduct> All();
        BordersPerProduct Find(int id);
        void Add(BordersPerProduct bordersPerProduct);
        void Update(BordersPerProduct bordersPerProduct);
        void Delete(int id);
    }
}
