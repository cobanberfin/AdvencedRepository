using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Models
{
    public class ProductModel
    {
        public Products Products { get; set; }
        public List<Products> plist { get; set; }
        public IEnumerable<SelectListItem> categorylist { get; set; }

    }
}