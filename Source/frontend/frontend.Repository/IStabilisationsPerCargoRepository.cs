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
        Task<IEnumerable<StabilisationsPerCargo>> GetAllStabilisationsPerCargos();
        Task<StabilisationsPerCargo> GetStabilisationsPerCargoById(int id);
        void AddStabilisationsPerCargo(StabilisationsPerCargo stabilisationsPerCargo);
        void UpdateStabilisationsPerCargo(StabilisationsPerCargo stabilisationsPerCargo);
        void DeleteStabilisationsPerCargo(int id);
    }
}
