using System;
using System.Collections;
using System.Data;
using System.Drawing;
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
		public void MssOCR(byte[] ssimage, out string ssresult, out decimal ssconfidence) {
			ssresult = "";

			byte[] myByteArray = new byte[10];
			MemoryStream stream = new MemoryStream(ssimage);
			Bitmap pic = new Bitmap(stream);
			for (int y = 0; (y <= (pic.Height - 1)); y++)
			{
				for (int x = 0; (x <= (pic.Width - 1)); x++)
				{
					Color inv = pic.GetPixel(x, y);
					inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
					pic.SetPixel(x, y, inv);
				}
			}
			ImageConverter converter = new ImageConverter();
			ssimage = (byte[])converter.ConvertTo(pic, typeof(byte[]));

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

