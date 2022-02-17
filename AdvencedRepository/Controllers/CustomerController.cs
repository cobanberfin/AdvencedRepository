using AdvencedRepository.Models;
using AdvencedRepository.Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvencedRepository.Controllers
{
    public class CustomerController : Controller
    {
        
       BaseRepository<Customer> rep = new BaseRepository<Customer>();
        CustomerModel model = new CustomerModel();

        // GET: Customer
        public ActionResult Index(string isim)
        {
            if (isim == null)
            {
                isim = " ";

            }
            model.clist = rep.GenelListe().Where(m => m.CompanyName.Contains(isim)).ToList();
            return View(model);
        }
    }
}