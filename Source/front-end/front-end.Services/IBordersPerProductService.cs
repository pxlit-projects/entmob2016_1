using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
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
