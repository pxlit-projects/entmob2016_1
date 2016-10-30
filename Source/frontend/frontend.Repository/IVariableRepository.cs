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
        Task<List<Variable>> GetAllVariables();
        Task<Variable> GetVariableById(int id);
    }
}
