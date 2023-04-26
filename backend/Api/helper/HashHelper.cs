using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace Api.helper
{
    public class HashHelper
    {
        public static HashedPassword Hash(string? password)
        {

            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password:password,
                salt:salt,
                prf:KeyDerivationPrf.HMACSHA256,
                iterationCount:10000,
                numBytesRequested:256 / 8));
            return new HashedPassword(){ Password = hashed, Salt= Convert.ToBase64String(salt) };

        }
        public static bool CheckHash( string attempedPassword, string hash, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: attempedPassword,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hash == hashed;
        }
        
        public static byte[] GetHash(string password, string hash)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(string.Concat(password, hash));
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);
            return hashedBytes;


        }



    }
    public class HashedPassword
    {
        public string? Password { get; set; }
        public string? Salt { get; set; }
    }

}


