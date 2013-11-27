using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
//using FaceDetectionLibrary;

namespace FaceDetectionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        //FaceDetection fd = new FaceDetection();

        public void detect(string fileName, Stream fileStream)
        {
            string destination_filename = "C:\\ImageProcessing\\Images\\Destination\\" + fileName;
            FileStream fileToupload = new FileStream(destination_filename, FileMode.Create);
            byte[] bytearray = new byte[5000000];
            int bytesRead, totalBytesRead = 0;
            fileStream.Position = 0;
            do
            {
                bytesRead = fileStream.Read(bytearray, 0, bytearray.Length);
                totalBytesRead += bytesRead;
            } while (bytesRead > 0);

            fileToupload.Write(bytearray, 0, totalBytesRead);
            fileToupload.Close();
            fileToupload.Dispose();

            // facedetection!
            byte[] bytes = Encoding.ASCII.GetBytes(destination_filename);
            unsafe
            {
                fixed (byte* p = bytes)
                {
                    sbyte* sp = (sbyte*)p;
                    //fd.detect(sp);
                }
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
