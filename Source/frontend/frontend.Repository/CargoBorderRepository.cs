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
        private ICargoRepository cargoRepository;

        public CargoBorderRepository(string username, string password)
        {
            cargoRepository = new CargoRepository(username, password);
        }

        public async void AddCargoBorder(CargoBorder cargoBorder)
        {
            var cargo = await cargoRepository.GetCargoById(cargoBorder.Cargo.Cargo_id);
            cargo.Borders.Add(cargoBorder);
            cargoRepository.UpdateCargo(cargo);
        }

        public async Task<List<CargoBorder>> GetAllCargoBorders()
        {
            var cargos = await cargoRepository.GetAllCargos();
            List<CargoBorder> cargoBorders = new List<CargoBorder>();
            cargos.ForEach(c => c.Borders.ForEach(b => cargoBorders.Add(b)));
            if (cargoBorders != null)
            {
                return cargoBorders;
            }
            else
            {
                return new List<CargoBorder>();
            }
        }

        public async Task<CargoBorder> GetCargoBorderById(int id)
        {
            var cargoBorders = await GetAllCargoBorders();
            var cargoBorder = cargoBorders.FirstOrDefault(c => c.Cargo_border_id == id);
            return cargoBorder;
        }
    }
}
