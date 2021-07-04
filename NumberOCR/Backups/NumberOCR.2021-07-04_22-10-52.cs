using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using Leptonica;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimePublic.Db;
using Tesseract;

namespace OutSystems.NssNumberOCR {

	public class CssNumberOCR: IssNumberOCR {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssimage"></param>
		/// <param name="ssresult"></param>
		/// <param name="ssconfidence"></param>
		
		public static void main(string[] args)
        {
			Console.WriteLine("xx");
        }
		public void MssOCR(byte[] ssimage, out string ssresult, out decimal ssconfidence) {
			ssresult = "";

            string appPath = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath);
            string path = appPath + @"\tessdata";
            if (!Directory.Exists(path))
			{
				path = appPath + @"\bin2\hidden_resources";
			}
			using (TessBaseAPI api = new TessBaseAPI(path, "digits", OcrEngineMode.LSTM_ONLY, PageSegmentationMode.AUTO))
			{
				using (Pix pix = ReadFile.pixReadMem(Marshal.UnsafeAddrOfPinnedArrayElement(ssimage, 0), (IntPtr)ssimage.Length))
				{
					api.SetImage(pix);
					ssresult = api.GetUTF8Text();
					ssconfidence = api.MeanTextConf;
				}
			}			
		} // MssOCR

	} // CssNumberOCR

} // OutSystems.NssNumberOCR

