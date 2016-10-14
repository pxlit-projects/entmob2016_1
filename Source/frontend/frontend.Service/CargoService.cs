using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;

namespace frontend.Service
{
    public class CargoService : ICargoService
    {
        private CargoRepository cargoRepository;

        public CargoService()
        {
            cargoRepository = new CargoRepository();
        }

        public void Add(Cargo cargo)
        {
            cargoRepository.AddCargo(cargo);
        }

        public List<Cargo> All()
        {
            return cargoRepository.GetAllCargos().Result.ToList();
        }

        public void Delete(int id)
        {
            cargoRepository.DeleteCargo(id);
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
