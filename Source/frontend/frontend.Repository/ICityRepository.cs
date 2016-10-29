using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCities();
        Task<City> GetCityById(int id);
        void AddCity(City city);
        void UpdateCity(City city);
    }
}
