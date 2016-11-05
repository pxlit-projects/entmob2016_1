using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;
using frontend.Repository;

namespace frontend.Service
{
    public class CargoService : ICargoService
    {
        private CargoRepository cargoRepository;

        public CargoService(string username, string password)
        {
            cargoRepository = new CargoRepository(username, password);
        }

        public void Add(Cargo cargo)
        {
            cargoRepository.AddCargo(cargo);
        }

        public List<Cargo> All()
        {
            return cargoRepository.GetAllCargos().Result.ToList();
        }

        public Cargo Find(int id)
        {
            return cargoRepository.GetCargoById(id).Result;
        }

        public void Update(Cargo cargo)
        {
            cargoRepository.UpdateCargo(cargo);
        }
    }
}
