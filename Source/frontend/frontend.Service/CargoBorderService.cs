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

        public CargoBorderService()
        {
            cargoBorderRepository = new CargoBorderRepository();
        }

        public void Add(CargoBorder cargoBorder)
        {
            cargoBorderRepository.AddCargoBorder(cargoBorder);
        }

        public List<CargoBorder> All()
        {
            return cargoBorderRepository.GetAllCargoBorders().Result.ToList();
        }

        public CargoBorder Find(int id)
        {
            return cargoBorderRepository.GetCargoBorderById(id).Result;
        }
    }
}
