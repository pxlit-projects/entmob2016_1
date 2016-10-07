using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
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
