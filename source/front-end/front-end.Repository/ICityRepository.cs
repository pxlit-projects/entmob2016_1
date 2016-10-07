using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCityById(int id);
        void AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int id);
    }
}
