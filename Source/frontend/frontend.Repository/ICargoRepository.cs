using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface ICargoRepository
    {
        Task<List<Cargo>> GetAllCargos();
        Task<Cargo> GetCargoById(int id);
        void AddCargo(Cargo cargo);
        void UpdateCargo(Cargo cargo);
    }
}
