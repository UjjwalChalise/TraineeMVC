using System.Security.Cryptography;

namespace TraineeMVC.Services
{
    public class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;
        private static readonly HashAlgorithmName Algo = HashAlgorithmName.SHA256;

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algo, KeySize);
            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        public bool Verify(string password, string stored)
        {
            var parts = stored.Split('.', 3);
            int iterations = int.Parse(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] hash = Convert.FromBase64String(parts[2]);

            byte[] attempt = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, Algo, hash.Length);
            return CryptographicOperations.FixedTimeEquals(hash, attempt); // avoids timing attacks
        }
    }
}
