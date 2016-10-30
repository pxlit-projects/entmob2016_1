using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface ILoginRepository
    {
        Task<List<Login>> GetAllLogins();
        Task<Login> GetLoginById(int id);
        void AddLogin(Login login);
    }
}
