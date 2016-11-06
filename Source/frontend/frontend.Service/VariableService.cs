using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class VariableService : IVariableService
    {
        private VariableRepository variableRepository;

        public VariableService(string username, string password)
        {
            variableRepository = new VariableRepository(username, password);
        }
        
        public List<Variable> All()
        {
            var variables = variableRepository.GetAllVariables().Result.ToList();
            if (variables != null)
            {
                return variables;
            }
            else
            {
                return new List<Variable>();
            }
        }

        public Variable Find(int id)
        {
            var variable = variableRepository.GetVariableById(id).Result;
            if (variable != null)
            {
                return variable;
            }
            else
            {
                return new Variable();
            }
        }
    }
}
