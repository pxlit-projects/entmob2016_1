using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface ICargoBorderRepository
    {
        Task<List<CargoBorder>> GetAllCargoBorders();
        Task<CargoBorder> GetCargoBorderById(int id);
        void AddCargoBorder(CargoBorder cargoBorder);
    }
}
