using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public interface ILoginService
    {
        List<Login> All();
        Login Find(int id);
        void Add(Login login);
        void Update(Login login);
        void Delete(int id);
    }
}
