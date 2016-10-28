using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class StabilisationsPerCargoService : IStabilisationsPerCargoService
    {
        private StabilisationsPerCargoRepository stabilisationsPerCargoRepository;

        public StabilisationsPerCargoService()
        {
            stabilisationsPerCargoRepository = new StabilisationsPerCargoRepository();
        }

        public void Add(StabilisationPerCargo stabilisationsPerCargo)
        {
            stabilisationsPerCargoRepository.AddStabilisationsPerCargo(stabilisationsPerCargo);
        }

        public List<StabilisationPerCargo> All()
        {
            return stabilisationsPerCargoRepository.GetAllStabilisationsPerCargos().Result.ToList();
        }

        public void Delete(int id)
        {
            stabilisationsPerCargoRepository.DeleteStabilisationsPerCargo(id);
        }

        public StabilisationPerCargo Find(int id)
        {
            return stabilisationsPerCargoRepository.GetStabilisationsPerCargoById(id).Result;
        }

        public void Update(StabilisationPerCargo stabilisationsPerCargo)
        {
            stabilisationsPerCargoRepository.UpdateStabilisationsPerCargo(stabilisationsPerCargo);
        }
    }
}
