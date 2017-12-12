using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiAngularJsUploader.Controllers.Photo;

namespace WebApiAngularJsUploader.Controllers
{
    [RoutePrefix("api/photo")]
    public class PhotoController : ApiController
    {
        private IPhotoManager photoManager;

        public PhotoController()
            : this(new LocalPhotoManager(HttpRuntime.AppDomainAppPath + @"\Album"))
        {            
        }

        public PhotoController(IPhotoManager photoManager)
        {
            this.photoManager = photoManager;
        }

        // POST: api/Photo
        public async Task<IHttpActionResult> Post()
        {
            // Check if the request contains multipart/form-data.
            if(!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }

            try
            {
                var photos = await photoManager.Add(Request);
                return Ok(new { Message = "Photos uploaded ok", Photos = photos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
