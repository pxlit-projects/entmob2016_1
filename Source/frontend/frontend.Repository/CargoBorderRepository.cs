using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;
using System.Net.Http;
using System.Net.Http.Headers;

namespace frontend.Repository
{
    public class CargoBorderRepository : ICargoBorderRepository
    {
        public ICargoRepository CargoRepository { get; set; }

        public CargoBorderRepository(string username, string password)
        {
            CargoRepository = new CargoRepository(username, password);
        }

        public async void AddCargoBorder(CargoBorder cargoBorder)
        {
            var cargo = await CargoRepository.GetCargoById(cargoBorder.Cargo.Cargo_id);
            cargo.Borders.Add(cargoBorder);
            CargoRepository.UpdateCargo(cargo);
        }

        public async Task<List<CargoBorder>> GetAllCargoBorders()
        {
            var cargos = await CargoRepository.GetAllCargos();
            List<CargoBorder> cargoBorders = new List<CargoBorder>();
            cargos.ForEach(c => c.Borders.ForEach(b => cargoBorders.Add(b)));
            return cargoBorders;
        }

        public async Task<CargoBorder> GetCargoBorderById(int id)
        {
            var cargoBorders = await GetAllCargoBorders();
            var cargoBorder = cargoBorders.FirstOrDefault(c => c.Cargo_border_id == id);
            return cargoBorder;
        }
    }
}
