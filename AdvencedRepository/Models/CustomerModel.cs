using AdvencedRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class CustomerModel
    {
        public Customer Customer { get; set; }

        public List<Customer> clist { get; set; }

    }
}