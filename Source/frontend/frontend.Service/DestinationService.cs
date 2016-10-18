using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace frontend.Service
{
    public class DestinationService : IDestinationService
    {
        private DestinationRepository destinationRepository;

        public DestinationService()
        {
            destinationRepository = new DestinationRepository();
        }

        public void Add(Destination destination)
        {
            destinationRepository.AddDestination(destination);
        }

        public List<Destination> All()
        {
            return destinationRepository.GetAllDestinations().Result.ToList();
        }

        public void Delete(int id)
        {
            destinationRepository.DeleteDestination(id);
        }

        public Destination Find(int id)
        {
            return destinationRepository.GetDestinationById(id).Result;
        }

        public void Update(Destination destination)
        {
            destinationRepository.UpdateDestination(destination);
        }
    }
}
