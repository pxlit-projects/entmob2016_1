using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface IVariableRepository
    {
        Task<IEnumerable<Variable>> GetAllVariables();
        Task<Variable> GetVariableById(int id);
        void AddVariable(Variable variable);
        void UpdateVariable(Variable variable);
        void DeleteVariable(int id);
    }
}
