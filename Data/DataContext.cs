using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ef_core_app.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }
        public DbSet<Kurs> Kurslar => Set<Kurs>();  

        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();  

        public DbSet<KursKayit> Kayitlar  => Set<KursKayit>();  

        public DbSet<Ogretmen> Ogretmenler  => Set<Ogretmen>();  
    }
}