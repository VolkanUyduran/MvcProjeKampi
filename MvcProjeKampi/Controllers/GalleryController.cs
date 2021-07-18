using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ImageFileManager = new ImageFileManager(new EfImageDal());
        public ActionResult Index()
        {
            var files=ImageFileManager.GetList();
            return View(files);
        }
        [HttpGet]
        public ActionResult AddImage()
        {
            ImageViewModel imageModel = new ImageViewModel() { FileAttach = null, Message = string.Empty, IsValid = false };

            try { }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return this.View(imageModel);
        }
        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult AddImage(ImageViewModel imageModel, ImageFile imageFile)
        {
            //Eger dosya yolu mevcut degilse,yeni dosya yolu olustur
            string folderPath = Server.MapPath("~/Images/Gallery/");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            try
            {
                // Dogrulama Islemleri
                if (ModelState.IsValid)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string expansion = Path.GetExtension(Request.Files[0].FileName);
                    string path = "/Images/Gallery/" + fileName + expansion;

                    //Dosya yükleme istek kontrolü
                    if (Request.Files.Count > 0)
                    {
                        var fullPath = Server.MapPath("/Images/Gallery/") + fileName + expansion;
                        //Resim dosyasi isim kontrolü
                        if (System.IO.File.Exists(fullPath))
                        {
                            ViewBag.ActionMessage = "Bu dosya adında başka bir resim mevcuttur";
                        }
                        else
                        {
                            Request.Files[0].SaveAs(Server.MapPath(path));
                            imageFile.ImageName = fileName;
                            imageFile.ImagePath = "/Images/Gallery/" + fileName + expansion;
                            ImageFileManager.ImageAdd(imageFile);
                            //ViewBag.ActionMessage = "Resim yükleme başarıyla gerçekleşmiştir.";
                            imageModel.Message = "'" + imageModel.FileAttach.FileName + "' dosya yükleme başarılı.   ";
                            return RedirectToAction("Index");
                        }
                    }

                    // Ayarlar - Dogrulama gecerliyse 
                    //imageModel.Message = "'" + imageModel.FileAttach.FileName + "' dosya yükleme başarılı.   ";
                    imageModel.IsValid = true;
                }
                else
                {
                    // Ayarlar - Dogrulama gecersizse  
                    imageModel.Message = "'" + imageModel.FileAttach.FileName + "' dosya yükleme başarısız!   ";
                    imageModel.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
            return View(imageModel);
        }
        [HttpGet]
        public ActionResult UpdateImage(int id)
        {
            ImageViewModel updateModel = new ImageViewModel();


            List<SelectListItem> _valueImage = (from x in ImageFileManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ImageName,
                                                    Value = x.ImageID.ToString()
                                                }).ToList();
            ViewBag.valueImage = _valueImage;
            ViewData["Image"] = ImageFileManager.GetByIdImageFile(id);
            ViewData["Models"] = updateModel;
            return View(_valueImage);
        }
        [HttpPost]
        public ActionResult UpdateImage(ImageFile imageFile, string[] DynamicTextBox)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.Values = serializer.Serialize(DynamicTextBox);

            string message = "";

            foreach (string textboxValue in DynamicTextBox)
            {
                message = textboxValue;
            }
            ViewBag.Message = message;
            ImageFileManager.ImageUpdate(imageFile);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteImage(int Id)
        {
            var imageValues = ImageFileManager.GetByIdImageFile(Id);
            ImageFileManager.ImageDelete(imageValues);
            return RedirectToAction("Index");
        }

    }

}