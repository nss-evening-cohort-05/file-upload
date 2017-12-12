using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiAngularJsUploader.Controllers.Photo
{
    public class LocalPhotoManager : IPhotoManager
    {
        public LocalPhotoManager(string workingFolder)
        {
            WorkingFolder = workingFolder;
            CheckTargetDirectory();
        }

        string WorkingFolder { get; }

        public async Task<IEnumerable<string>> Add(HttpRequestMessage request)
        {
            var provider = new PhotoMultipartFormDataStreamProvider(WorkingFolder);

            await request.Content.ReadAsMultipartAsync(provider);

            var photos = new List<string>();

            foreach (var file in provider.FileData)
            {
                var fileInfo = new FileInfo(file.LocalFileName);

                photos.Add(fileInfo.Name);
            }

            return photos;
        }

        public bool FileExists(string fileName)
        {
            var file = Directory.GetFiles(WorkingFolder, fileName)
                .FirstOrDefault();

            return file != null;
        }

        void CheckTargetDirectory()
        {
            if (!Directory.Exists(WorkingFolder))
                throw new ArgumentException("the destination path " + WorkingFolder + " could not be found");
        }
    }
}