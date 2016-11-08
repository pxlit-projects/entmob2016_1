using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class ExceedingsPerCargoService : IExceedingsPerCargoService
    {
        private ExceedingsPerCargoRepository exceedingsPerCargoRepository;

        public ExceedingsPerCargoService(string username, string password)
        {
            exceedingsPerCargoRepository = new ExceedingsPerCargoRepository(username, password);
        }

        public void Add(ExceedingPerCargo exceedingsPerCargo)
        {
            exceedingsPerCargoRepository.AddExceedingsPerCargo(exceedingsPerCargo);
        }

        public List<ExceedingPerCargo> All()
        {
            var exceedings = exceedingsPerCargoRepository.GetAllExceedingsPerCargos().Result.ToList();
            if (exceedings != null)
            {
                return exceedings;
            }
            else
            {
                return new List<ExceedingPerCargo>();
            }
        }

        public ExceedingPerCargo Find(int id)
        {
            var exceeding = exceedingsPerCargoRepository.GetExceedingsPerCargoById(id).Result;
            if (exceeding != null)
            {
                return exceeding;
            }
            else
            {
                return new ExceedingPerCargo();
            }
        }
    }
}
