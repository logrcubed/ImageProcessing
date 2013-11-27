using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestImageProcessor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ImageUploadService : IImageUpload
    {
        public void FileUpload(string fileName, Stream fileStream)
        {

            FileStream fileToupload = new FileStream("C:\\ImageProcessing\\Images\\Destination\\" + fileName, FileMode.Create);

            byte[] bytearray = new byte[5000000];
            int bytesRead, totalBytesRead = 0;
            do
            {
                bytesRead = fileStream.Read(bytearray, 0, bytearray.Length);
                totalBytesRead += bytesRead;
            } while (bytesRead > 0);

            fileToupload.Write(bytearray, 0, bytearray.Length);
            fileToupload.Close();
            fileToupload.Dispose();

        }
    }
}
