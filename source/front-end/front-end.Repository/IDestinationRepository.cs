using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public interface IDestinationRepository
    {
        Task<IEnumerable<Destination>> GetAllDestinations();
        Task<Destination> GetDestinationById(int id);
        void AddDestination(Destination destination);
        void UpdateDestination(Destination destination);
        void DeleteDestination(int id);
    }
}
