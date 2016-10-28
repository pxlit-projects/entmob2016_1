using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface IExceedingsPerCargoRepository
    {
        Task<IEnumerable<ExceedingPerCargo>> GetAllExceedingsPerCargos();
        Task<ExceedingPerCargo> GetExceedingsPerCargoById(int id);
        void AddExceedingsPerCargo(ExceedingPerCargo exceedingsPerCargo);
        void UpdateExceedingsPerCargo(ExceedingPerCargo exceedingsPerCargo);
        void DeleteExceedingsPerCargo(int id);
    }
}
