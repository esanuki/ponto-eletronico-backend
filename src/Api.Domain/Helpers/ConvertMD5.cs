using System.Security.Cryptography;
using System.Text;

namespace Api.Domain.Helpers
{
    public static class ConvertMD5
    {
        public static string CriptografiaMD5(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
                
        }
    }
}
