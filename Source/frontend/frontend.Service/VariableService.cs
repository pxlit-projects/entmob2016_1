using frontend.Domain;
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

        public VariableService()
        {
            variableRepository = new VariableRepository();
        }

        public void Add(Variable variable)
        {
            variableRepository.AddVariable(variable);
        }

        public List<Variable> All()
        {
            return variableRepository.GetAllVariables().Result.ToList();
        }

        public void Delete(int id)
        {
            variableRepository.DeleteVariable(id);
        }

        public Variable Find(int id)
        {
            return variableRepository.GetVariableById(id).Result;
        }

        public void Update(Variable variable)
        {
            variableRepository.UpdateVariable(variable);
        }
    }
}
