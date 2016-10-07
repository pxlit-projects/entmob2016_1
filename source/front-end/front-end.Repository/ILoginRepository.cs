using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public interface ILoginRepository
    {
        Task<IEnumerable<Login>> GetAllLogins();
        Task<Login> GetLoginById(int id);
        void AddLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(int id);
    }
}
