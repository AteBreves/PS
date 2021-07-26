using System;
using System.Collections;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform;

namespace OutSystems.NssGenerateRandomString {

	public interface IssGenerateRandomString {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssrandom"></param>
		/// <param name="sslength"></param>
		void MssGenerateRandomString(out string ssrandom, int sslength);

	} // IssGenerateRandomString

} // OutSystems.NssGenerateRandomString
