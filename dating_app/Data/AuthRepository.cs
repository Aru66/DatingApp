using System;
using System.Threading.Tasks;
using dating_app.Model;

namespace dating_app.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContex _Contex;
        public AuthRepository(DataContex Contex)
        {
            _Contex = Contex;

        }
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User User, string Password)
        {
            byte[] passwordHash,passwordSalt;
            CreatePaswordHash(Password,out passwordHash, out passwordSalt);
            User.PasswordSalt=passwordSalt;
            User.PasswordHash=passwordHash;

            await _Contex.AddAsync(User);
            await _Contex.SaveChangesAsync();
            return User;
        }

        private void CreatePaswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using(var HMAC=new System.Security.Cryptography.HMACSHA512())
           {
              passwordSalt=HMAC.Key;
              passwordHash=HMAC.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           }
        }

        public Task<bool> UserExist(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}