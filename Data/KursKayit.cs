using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_app.Data
{
    public class KursKayit
    {
        [Key]
        public int KayitId { get; set; }

        public int OgrenciId { get; set; }

        public Ogrenci Ogrenci {get; set;} = null! ; 

        public int KursId { get; set; }


        public Kurs Kurs {get; set;} = null! ;


        public DateTime KayitTarihi { get; set; }

    


    }
}