using System;
using System.IO;
using System.Net;
using System.Drawing;

namespace FaceCaptureClient
{
    public class Program
    {
	static void Main(string[] args)
        {
            byte[] bytearray = null;

            string name = "PictureX.jpg";

	    Console.Write(" a ");
            Image im = Image.FromFile("/home/pi/gpioproject/image.jpg"); // big file
            //Image im = Image.FromFile("C:\\ImageProcessing\\Images\\Source\\Picture2.jpg");
            //Image im = Image.FromFile("C:\\ImageProcessing\\Images\\Source\\Picture3.jpg");
            //Image im = Image.FromFile("C:\\ImageProcessing\\Images\\Source\\Picture4.jpg");
            //Image im = Image.FromFile("C:\\ImageProcessing\\Images\\Source\\Picture5.jpg");

	    Console.Write("b");
            bytearray = Program.imageToByteArray(im);

            Console.Write(" c ");
            string baseAddress = "http://192.168.1.6:8000/Service/FileUpload/";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(baseAddress + name);
            request.Method = "POST";
            request.ContentType = "text/plain";
            request.ContentLength = bytearray.Length;
          
	    Console.Write(" d ");
            Stream serverStream = request.GetRequestStream();
            serverStream.Write(bytearray, 0, bytearray.Length);
            serverStream.Close();

	    Console.Write(" e ");
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
		Console.Write(" f ");
                int statusCode = (int)response.StatusCode;
                StreamReader reader = new StreamReader(response.GetResponseStream());
            }
	Console.Write(" g ");
        }

        public static byte[] imageToByteArray(Image imageIn)
        {
	    Console.Write(" inside function image to byte array ");
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
