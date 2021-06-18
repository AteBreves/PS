using System;
using System.Collections;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform;

namespace OutSystems.NssNumberOCR {

	public interface IssNumberOCR {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssimage"></param>
		/// <param name="ssresult"></param>
		/// <param name="ssconfidence"></param>
		void MssOCR(byte[] ssimage, out string ssresult, out decimal ssconfidence);

	} // IssNumberOCR

} // OutSystems.NssNumberOCR
