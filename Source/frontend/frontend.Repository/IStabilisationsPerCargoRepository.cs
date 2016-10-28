using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface IStabilisationsPerCargoRepository
    {
        Task<IEnumerable<StabilisationPerCargo>> GetAllStabilisationsPerCargos();
        Task<StabilisationPerCargo> GetStabilisationsPerCargoById(int id);
        void AddStabilisationsPerCargo(StabilisationPerCargo stabilisationsPerCargo);
        void UpdateStabilisationsPerCargo(StabilisationPerCargo stabilisationsPerCargo);
        void DeleteStabilisationsPerCargo(int id);
    }
}
