using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO; 

namespace RestImageProcessor
{
    [ServiceContract]
    public interface IImageUpload
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "FileUpload/{fileName}")]
        void FileUpload(string fileName, Stream fileStream);

    } 
}
