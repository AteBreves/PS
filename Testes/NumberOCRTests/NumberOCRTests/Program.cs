using Leptonica;
using System;
using System.Runtime.InteropServices;
using Tesseract;
using System.Drawing;
using System.IO;

namespace NumberOCRTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Image img = Image.FromFile("./images/contador.jpg");
			ImageConverter imageConverter = new ImageConverter();
			byte[] arr = (byte[])imageConverter.ConvertTo(img, typeof(byte[]));
			string r;
			decimal confidence;
			MssOCR(arr, out r, out confidence);

		}
		public static void MssOCR(byte[] ssimage, out string ssresult, out decimal ssconfidence)
		{
			ssresult = "";
			ssconfidence = 69M;
			//********
			string dataPath = "./tessdata/";
			string language = "digits";
			OcrEngineMode oem = OcrEngineMode.DEFAULT;
			PageSegmentationMode psm = PageSegmentationMode.AUTO_OSD;

			TessBaseAPI tessBaseAPI = new TessBaseAPI();

			// Initialize tesseract-ocr 
			if (!tessBaseAPI.Init(dataPath, language, oem))
			{
				throw new Exception("Could not initialize tesseract.");
			}

			// Set the Page Segmentation mode
			tessBaseAPI.SetPageSegMode(psm);


			//*************************
			using (TessBaseAPI api = new TessBaseAPI("./tessdata", "digits", OcrEngineMode.LSTM_ONLY, PageSegmentationMode.AUTO))
			{
				
				using (Pix pix = ReadFile.pixReadMem(Marshal.UnsafeAddrOfPinnedArrayElement(ssimage, 0), (IntPtr)ssimage.Length))
				{
					api.SetImage(pix);
					ssresult = api.GetUTF8Text();
					//ssconfidence = api.MeanTextConf;
				}
			}
		} // MssOCR
	}
}
