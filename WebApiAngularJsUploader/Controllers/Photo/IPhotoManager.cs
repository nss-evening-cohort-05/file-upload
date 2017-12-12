using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiAngularJsUploader.Controllers.Photo
{
    public interface IPhotoManager
    {
        Task<IEnumerable<string>> Add(HttpRequestMessage request);
        bool FileExists(string fileName);
    }
}
