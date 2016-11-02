using frontend.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public class ExceedingsPerCargoRepository : IExceedingsPerCargoRepository
    {
        public ICargoRepository CargoRepository { get; set; }

        public ExceedingsPerCargoRepository(string username, string password)
        {
            CargoRepository = new CargoRepository(username, password);
        }

        public async Task<List<ExceedingPerCargo>> GetAllExceedingsPerCargos()
        {
            var cargos = await CargoRepository.GetAllCargos();
            List<ExceedingPerCargo> exceedingPerCargos = new List<ExceedingPerCargo>();
            cargos.ForEach(c => c.Exceedings.ForEach(e => exceedingPerCargos.Add(e)));
            return exceedingPerCargos;
        }

        public async Task<ExceedingPerCargo> GetExceedingsPerCargoById(int id)
        {
            var exceedingPerCargos = await GetAllExceedingsPerCargos();
            var exceedingPerCargo = exceedingPerCargos.FirstOrDefault(e => e.Exceeding_per_cargo_id == id);
            return exceedingPerCargo;
        }

        public async void AddExceedingsPerCargo(ExceedingPerCargo exceedingPerCargo)
        {
            var cargo = await CargoRepository.GetCargoById(exceedingPerCargo.Cargo.Cargo_id);
            cargo.Exceedings.Add(exceedingPerCargo);
            CargoRepository.UpdateCargo(cargo);
        }
    }
}
