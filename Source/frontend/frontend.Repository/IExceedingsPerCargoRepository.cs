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
        Task<List<ExceedingPerCargo>> GetAllExceedingsPerCargos();
        Task<ExceedingPerCargo> GetExceedingsPerCargoById(int id);
        void AddExceedingsPerCargo(ExceedingPerCargo exceedingsPerCargo);
    }
}
