using System;
using System.Security.Cryptography;
using System.Text;

namespace random
{
    class Program
    {

		static void Main(string[] args)
		{
			string result1 = MssGenerateRandomString(20);
			string result2 = MssGenerateRandomString(20);
			Boolean eq = result1 != result2;
			Console.WriteLine("The 2 strings generated are different: " + eq);
			string result3 = MssGenerateRandomString(15);
			Boolean r3 = result3.Length == 15;
			Boolean r1 = result1.Length == 20;
			Console.WriteLine("The strings have correct size: " + r3 + " " + r1);
		}

		public static string MssGenerateRandomString(int sslength)
		{
			if (sslength < 0 || sslength > 100)
			{
				sslength = 20;
			}
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				byte[] letter = new byte[1];
				StringBuilder res = new StringBuilder();
				int i = 0;
				while (i < sslength)
				{
					char c = '\0';
					do
					{
						rng.GetBytes(letter);
						c = Convert.ToBase64String(letter).ToCharArray()[0];
					} while (!char.IsLetterOrDigit(c));
					res.Append(c);
					i++;
				}
				return res.ToString();
			}

		} // MssGenerateRandomString

	}
}
