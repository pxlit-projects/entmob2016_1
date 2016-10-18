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

        public ExceedingsPerCargoService()
        {
            exceedingsPerCargoRepository = new ExceedingsPerCargoRepository();
        }

        public void Add(ExceedingsPerCargo exceedingsPerCargo)
        {
            exceedingsPerCargoRepository.AddExceedingsPerCargo(exceedingsPerCargo);
        }

        public List<ExceedingsPerCargo> All()
        {
            return exceedingsPerCargoRepository.GetAllExceedingsPerCargos().Result.ToList();
        }

        public void Delete(int id)
        {
            exceedingsPerCargoRepository.DeleteExceedingsPerCargo(id);
        }

        public ExceedingsPerCargo Find(int id)
        {
            return exceedingsPerCargoRepository.GetExceedingsPerCargoById(id).Result;
        }

        public void Update(ExceedingsPerCargo exceedingsPerCargo)
        {
            exceedingsPerCargoRepository.UpdateExceedingsPerCargo(exceedingsPerCargo);
        }
    }
}
