using BookAndShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAndShop.Controllers.UploadImageControllers
{

    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Upload")]
    public class UploadController : ControllerBase
    {
        protected string ContentRootPath { get; set; }
        MyDbContext Context { get; set; }
        public UploadController(IWebHostEnvironment hostingEnvironment, MyDbContext context)
        {
            ContentRootPath = hostingEnvironment.WebRootPath;
            Context = context;
        }
        public string GetOrCreateUploadFolder()
        {
            var path = Path.Combine(ContentRootPath, "images\\forBook");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        [HttpPost("UploadFile")]
        public ActionResult UploadFile(IFormFile myFile)
        {
            try
            {
                var path = GetOrCreateUploadFolder();
                using (var fileStream = System.IO.File.Create(Path.Combine(path, myFile.FileName)))
                {
                    myFile.CopyTo(fileStream);
                }

                var img = new Image { Path = Path.Combine("images\\forBook", myFile.FileName) };
                Context.Images.Add(img);
                Context.SaveChanges();
            }
            catch
            {
                Response.StatusCode = 400;
            }
            return new EmptyResult();
        }
    }
}
