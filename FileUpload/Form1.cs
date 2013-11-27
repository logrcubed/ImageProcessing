using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileUpload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bytearray = null;

            string name = "image.jpg";

            Image im = Image.FromFile("C:\\ImageProcessing\\Images\\Source\\2.jpg"); // big file
            //Image im = Image.FromFile("C:\\Users\\trilok.rangan\\Desktop\\RPi\\Images\\Source\\small.jpg");

            bytearray = imageToByteArray(im);
            
            string baseAddress = "http://localhost:8000/Service/FileUpload/";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(baseAddress + name);
            request.Method = "POST";
            request.ContentType = "text/plain";
            request.ContentLength = bytearray.Length;
          
            Stream serverStream = request.GetRequestStream();
            serverStream.Write(bytearray, 0, bytearray.Length);
            serverStream.Close();
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                int statusCode = (int)response.StatusCode;
                StreamReader reader = new StreamReader(response.GetResponseStream());
            }
        }

        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
