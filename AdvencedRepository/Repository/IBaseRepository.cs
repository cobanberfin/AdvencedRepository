using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvencedRepository.Repository
{
 public  interface IBaseRepository<T>where T:class,new()
    {
        DbSet<T> Set();

        T Bul(int id); //t tipinde gerı deger donduren metot
        T Bul(string id);

        void Sil(T entity);

        int Guncellenenkayit();
        void Guncel();

        List<T> Listele();

        void Ekle(T entity);

        IQueryable<T> GenelListe();


    }
}
