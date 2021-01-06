using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public static class HashService
    {
        public static string HashString(string text)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool CompareHash(string text, string hash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                text = HashString(text);
                return text == hash;
            }
        }
    }
}
