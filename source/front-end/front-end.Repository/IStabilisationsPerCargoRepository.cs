using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public interface IStabilisationsPerCargoRepository
    {
        Task<IEnumerable<StabilisationsPerCargo>> GetAllStabilisationsPerCargos();
        Task<StabilisationsPerCargo> GetStabilisationsPerCargoById(int id);
        void AddStabilisationsPerCargo(StabilisationsPerCargo stabilisationsPerCargo);
        void UpdateStabilisationsPerCargo(StabilisationsPerCargo stabilisationsPerCargo);
        void DeleteStabilisationsPerCargo(int id);
    }
}
