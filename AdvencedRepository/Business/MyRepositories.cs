using AdvencedRepository.Models;
using AdvencedRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvencedRepository.Business
{
    public class MyRepositories
    {
        public class CategoriesRepository : BaseRepository<Category>
        {

        }
        public class ProductRepository : BaseRepository<Product>
        {

        }

        public class CustomerRepository : BaseRepository<Customer>
        {

        }


    }
}