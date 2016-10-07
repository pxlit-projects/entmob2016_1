using front_end.Repository;
using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public class CityService : ICityService
    {
        private CityRepository cityRepository;

        public CityService()
        {
            cityRepository = new CityRepository();
        }

        public void Add(City city)
        {
            cityRepository.AddCity(city);
        }

        public List<City> All()
        {
            return cityRepository.GetAllCities().Result.ToList();
        }

        public void Delete(int id)
        {
            cityRepository.DeleteCity(id);
        }

        public City Find(int id)
        {
            return cityRepository.GetCityById(id).Result;
        }

        public void Update(City city)
        {
            cityRepository.UpdateCity(city);
        }
    }
}
