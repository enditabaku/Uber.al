using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UberDriver.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public AdminController()
        {
        }
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult Edit(int albumId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //album.ImageMimeType = image.ContentType;
                   // album.ImageData = new byte[image.ContentLength];
                    //image.InputStream.Read(album.ImageData, 0, image.ContentLength);
                }
                //repository.SaveAlbum(album);
                //TempData["message"] = string.Format("{0} has been saved", album.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ViewResult Create()
        {
            return View("Edit");
        }
        [HttpPost]
        public ActionResult Delete(int albumId)
        {
            //Album deletedAlbum = repository.DeleteAlbum(albumId);
            //if (deletedAlbum != null)
            //{
            //    TempData["message"] = string.Format("{0} was deleted", deletedAlbum.Title);
            //}
            return RedirectToAction("Index");
        }
    }
}