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
                if (file.ContentType.Contains("image")) {
                    if (file.ContentLength > 0)
                    {
                        string datenow = DateTime.Now.ToString("yyyyMMddhhmmss");
                        //string datenow = now.ToString(HHmmss);
                        string FileName = Path.GetFileName(file.FileName);
                        FileName = datenow + "_" + FileName;
                        string FilePath = Path.Combine(Server.MapPath("~/UploadedFiles"), FileName);
                        string dpath = "~/UploadedFiles/"+FileName;
                        file.SaveAs(FilePath);
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                    return View();
                }
                return View();
            }
            catch (Exception)
            {

                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult ViewImage()
        {

            return View();
        }

    }

    
}