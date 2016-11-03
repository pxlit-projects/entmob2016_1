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
        public ICargoRepository CargoRepository { get; set; }

        public VariableRepository(string username, string password)
        {
            CargoRepository = new CargoRepository(username, password);
        }

        public async Task<List<Variable>> GetAllVariables()
        {
            var cargos = await CargoRepository.GetAllCargos();
            HashSet<int> variablesId = new HashSet<int>();
            List<Variable> variables = new List<Variable>();
            cargos.ForEach(c => c.Borders.ForEach(b => variablesId.Add(b.Variable.Variable_id)));

            foreach (int id in variablesId)
            {
                variables.Add(await GetVariableById(id));
            }

            return variables;
        }

        public async Task<Variable> GetVariableById(int id)
        {
            var variables = await GetAllVariables();
            var variable = variables.FirstOrDefault(v => v.Variable_id == id);
            return variable;
        }
    }
}
