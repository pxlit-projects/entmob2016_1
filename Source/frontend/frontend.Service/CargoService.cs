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
            var cargos = cargoRepository.GetAllCargos().Result.ToList();
            if (cargos != null)
            {
                return cargos;
            }
            else
            {
                return new List<Cargo>();
            }
        }

        public Cargo Find(int id)
        {
            var cargo = cargoRepository.GetCargoById(id).Result;
            if (cargo != null)
            {
                return cargo;
            }
            else
            {
                return new Cargo();
            }
        }

        public void Update(Cargo cargo)
        {
            cargoRepository.UpdateCargo(cargo);
        }
    }
}
