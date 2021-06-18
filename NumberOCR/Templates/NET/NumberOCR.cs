using System;
using System.Collections;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimePublic.Db;

namespace OutSystems.NssNumberOCR {

	public class CssNumberOCR: IssNumberOCR {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssimage"></param>
		/// <param name="ssresult"></param>
		/// <param name="ssconfidence"></param>
		public void MssOCR(byte[] ssimage, out string ssresult, out decimal ssconfidence) {
			ssresult = "";
			ssconfidence = 0.0M;
			// TODO: Write implementation for action
		} // MssOCR

	} // CssNumberOCR

} // OutSystems.NssNumberOCR

