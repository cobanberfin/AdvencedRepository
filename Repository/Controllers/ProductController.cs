using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository rep = new ProductRepository();
        ProductModel model = new ProductModel();
        BaseRepository<Categories> repcategory = new BaseRepository<Categories>();

        public ActionResult Index(string name)
        {
            if (name == null)
            {
                name = "";
            }
            model.plist = rep.GenelListe().Where(x => x.ProductName.Contains(name)).ToList();//ıstege gore arma yapma


            return View(model);
        }
        public ActionResult Detay(int id)
        {
            model.Products = rep.Bul(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            model.Products = rep.Bul(id);
            model.categorylist = repcategory.GenelListe().Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()

            });
            return View(model);

            
        }
        [HttpPost]
        public ActionResult Guncelle(int id, ProductModel model)
        {
            Products secproduct = rep.Bul(id);
            secproduct.ProductName = model.Products.ProductName;
            secproduct.UnitPrice = model.Products.UnitPrice;
            secproduct.QuantityPerUnit = model.Products.QuantityPerUnit;
            secproduct.CategoryID = model.Products.CategoryID;
            secproduct.Discontinued = model.Products.Discontinued;
            rep.Guncel();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            Products p = rep.Bul(id);
            rep.Sil(p);
            rep.Guncel();
            return RedirectToAction("Index");
        }
        public ActionResult Ekle()//diğer nesneler bos ıken categorıler dolu gelcek
        {
            model.categorylist = repcategory.GenelListe().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            });
            return View(model);
        }
        [HttpPost]
        public ActionResult Ekle(ProductModel pm)
        {
            if (ModelState.IsValid)
            {
                model.categorylist = repcategory.GenelListe().Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                });
                Products p = new Products();
                p.ProductID = pm.Products.ProductID;
                p.ProductName = pm.Products.ProductName;
                p.UnitPrice = pm.Products.UnitPrice;
                p.QuantityPerUnit = pm.Products.QuantityPerUnit;
                p.Discontinued = pm.Products.Discontinued;
                p.CategoryID = pm.Products.CategoryID;
                rep.Ekle(p);
                rep.Guncel();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Sec()
        {//ilk 10 kişi dısnda kalan gelsin terten
            ProductModel pm = new ProductModel();
           
            pm.plist = rep.GenelListe().OrderByDescending(m => m.ProductID).Skip(10).ToList(); //10tane attık
            var x = pm.plist.Count();//10 kaydın atılmıs halı
            pm.plist = pm.plist.OrderBy(m => m.ProductID).Take(x - 20).ToList();

            return View(pm);
        }
    }
   


}