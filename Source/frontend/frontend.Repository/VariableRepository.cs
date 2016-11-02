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
    public class VariableRepository : IVariableRepository
    {
        public HttpClient Client { get; set; }

        public ICargoRepository CargoRepository { get; set; }

        public VariableRepository()
        {
            CargoRepository = new CargoRepository();
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Variable>> GetAllVariables()
        {
            var cargos = await CargoRepository.GetAllCargos();
            HashSet<Variable> variables = new HashSet<Variable>();
            cargos.ForEach(c => c.Borders.ForEach(b => variables.Add(b.Variable)));
            return variables.ToList();
        }

        public async Task<Variable> GetVariableById(int id)
        {
            var variables = await GetAllVariables();
            var variable = variables.FirstOrDefault(v => v.Variable_id == id);
            return variable;
        }
    }
}
