using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUpload.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string FileName = Path.GetFileName(file.FileName);
                    string FilePath = Path.Combine(Server.MapPath("~/UploadedFiles"), FileName);
                    file.SaveAs(FilePath);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch (Exception)
            {

                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

    }

    
}