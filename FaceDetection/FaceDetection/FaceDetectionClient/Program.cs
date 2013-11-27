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
using FaceDetectionService;

namespace FaceDetectionClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Image im = Image.FromFile("C:\\ImageProcessing\\Images\\Source\\Picture1.jpg"); // big file
            MemoryStream ms = new MemoryStream();
            im.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Service1 service = new Service1();
            service.detect("picture.jpg", ms);
        }
    }
}
