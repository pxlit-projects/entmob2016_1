using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class LoginService : ILoginService
    {
        private LoginRepository loginRepository;

        public LoginService()
        {
            loginRepository = new LoginRepository();
        }

        public void Add(Login login)
        {
            loginRepository.AddLogin(login);
        }

        public List<Login> All()
        {
            return loginRepository.GetAllLogins().Result.ToList();
        }

        public Login Find(int id)
        {
            return loginRepository.GetLoginById(id).Result;
        }
    }
}
