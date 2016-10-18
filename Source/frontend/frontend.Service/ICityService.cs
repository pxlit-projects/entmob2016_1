using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface ICityService
    {
        List<City> All();
        City Find(int id);
        void Add(City city);
        void Update(City city);
        void Delete(int id);
    }
}
