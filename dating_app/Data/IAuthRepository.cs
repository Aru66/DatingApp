using System.Threading.Tasks;
using dating_app.Model;

namespace dating_app.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User User, string Password);
         Task<User> Login(string username,string password);
         Task<bool> UserExist(string username);

    }
}