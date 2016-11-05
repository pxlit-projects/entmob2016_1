using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface ICargoBorderService
    {
        List<CargoBorder> All();
        CargoBorder Find(int id);
        void Add(CargoBorder cargoBorder);
    }
}
