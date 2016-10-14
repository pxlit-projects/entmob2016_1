using frontend.Domain;
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

        public void Add(StabilisationsPerCargo stabilisationsPerCargo)
        {
            stabilisationsPerCargoRepository.AddStabilisationsPerCargo(stabilisationsPerCargo);
        }

        public List<StabilisationsPerCargo> All()
        {
            return stabilisationsPerCargoRepository.GetAllStabilisationsPerCargos().Result.ToList();
        }

        public void Delete(int id)
        {
            stabilisationsPerCargoRepository.DeleteStabilisationsPerCargo(id);
        }

        public StabilisationsPerCargo Find(int id)
        {
            return stabilisationsPerCargoRepository.GetStabilisationsPerCargoById(id).Result;
        }

        public void Update(StabilisationsPerCargo stabilisationsPerCargo)
        {
            stabilisationsPerCargoRepository.UpdateStabilisationsPerCargo(stabilisationsPerCargo);
        }
    }
}
