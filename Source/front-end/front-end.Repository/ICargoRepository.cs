using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public interface ICargoRepository
    {
        Task<IEnumerable<Cargo>> GetAllCargos();
        Task<Cargo> GetCargoById(int id);
        void AddCargo(Cargo cargo);
        void UpdateCargo(Cargo cargo);
        void DeleteCargo(int id);
    }
}
