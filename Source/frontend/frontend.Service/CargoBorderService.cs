using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;
using frontend.Repository;

namespace frontend.Service
{
    public class CargoBorderService : ICargoBorderService
    {
        private CargoBorderRepository cargoBorderRepository;

        public CargoBorderService(string username, string password)
        {
            cargoBorderRepository = new CargoBorderRepository(username, password);
        }

        public void Add(CargoBorder cargoBorder)
        {
            cargoBorderRepository.AddCargoBorder(cargoBorder);
        }

        public List<CargoBorder> All()
        {
            var cargoBorders = cargoBorderRepository.GetAllCargoBorders().Result.ToList();
            return cargoBorders;
        }

        public CargoBorder Find(int id)
        {
            var cargoBorder = cargoBorderRepository.GetCargoBorderById(id).Result;
            if (cargoBorder != null)
            {
                return cargoBorder;
            }
            else
            {
                return new CargoBorder();
            }
        }
    }
}
