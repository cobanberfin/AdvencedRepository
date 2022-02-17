using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Controllers
{
    public class CategoryController : Controller
    {
        BaseRepository<Categories> rep = new BaseRepository<Categories>();
        CategoriesModel model = new CategoriesModel();
        // GET: Category
        public ActionResult Index(string name)
        {
            if (name == null)
            {
                name = "";
            }
            // model.clist = rep.Listele();
            model.clist = rep.GenelListe().Where(x => x.CategoryName.Contains(name)).ToList();
            return View(model);
        }
        public ActionResult Detay(int id)
        {
            model.Categories = rep.Bul(id);
            return View(model);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(CategoriesModel cm)
        {
            if (ModelState.IsValid)
            {
                Categories c = new Categories();
                c.CategoryID = cm.Categories.CategoryID;
                c.CategoryName = cm.Categories.CategoryName;
                c.Description = cm.Categories.Description;
                rep.Ekle(c);
                rep.Guncel();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Sil(int id)
        {
            Categories c = rep.Bul(id);
            rep.Sil(c);
            rep.Guncel();
            return RedirectToAction("Index");

        }

        public ActionResult Guncelle(int id)
        {
            model.Categories = rep.Bul(id);
            return View(model);

        }
        [HttpPost]
        public ActionResult Guncelle(int id, CategoriesModel cm)
        {
            if (ModelState.IsValid)
            {
                Categories seccategory = rep.Bul(id);
                seccategory.CategoryName = cm.Categories.CategoryName;
                seccategory.Description = cm.Categories.Description;
                rep.Guncel();
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Sec()
        {
            CategoriesModel c = new CategoriesModel();
            c.clist = rep.GenelListe().OrderBy(x => x.CategoryID).Skip(3).Take(5).ToList();



            return View(c);
        }
    }
}