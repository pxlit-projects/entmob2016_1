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

        public VariableService()
        {
            variableRepository = new VariableRepository();
        }
        
        public List<Variable> All()
        {
            return variableRepository.GetAllVariables().Result.ToList();
        }

        public Variable Find(int id)
        {
            return variableRepository.GetVariableById(id).Result;
        }
    }
}
