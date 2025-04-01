using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;

namespace PlusTrack.API.Application.Services
{


    public static class Crypter
    {


        public static string Hash(string clearTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(clearTextPassword, workFactor: 12);
        }


        public static bool Verify(string clearTextPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(clearTextPassword, hashedPassword);
        }
    }
}
