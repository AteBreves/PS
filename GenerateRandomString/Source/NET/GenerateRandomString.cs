using System;
using System.Collections;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimePublic.Db;

namespace OutSystems.NssGenerateRandomString {

	public class CssGenerateRandomString: IssGenerateRandomString {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssrandom"></param>
		public void MssGenerateRandomString(out string ssrandom, int sslength) {
			if(sslength < 0 || sslength > 100)
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
				ssrandom = res.ToString();
			}

		} // MssGenerateRandomString


	} // CssGenerateRandomString

} // OutSystems.NssGenerateRandomString

