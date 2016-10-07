using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public interface IVariableService
    {
        List<Variable> All();
        Variable Find(int id);
        void Add(Variable variable);
        void Update(Variable variable);
        void Delete(int id);
    }
}
