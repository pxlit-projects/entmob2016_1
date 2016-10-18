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
        Task<IEnumerable<ExceedingsPerCargo>> GetAllExceedingsPerCargos();
        Task<ExceedingsPerCargo> GetExceedingsPerCargoById(int id);
        void AddExceedingsPerCargo(ExceedingsPerCargo exceedingsPerCargo);
        void UpdateExceedingsPerCargo(ExceedingsPerCargo exceedingsPerCargo);
        void DeleteExceedingsPerCargo(int id);
    }
}
