using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_app.Data
{
    public   class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }

        [DisplayName("Öğrencinin Adı")]
        public string? OgrenciAd { get; set; }
        [DisplayName("Öğrencinin Soyadı")]
        public string? OgrenciSoyad { get; set; }
        public string AdSoyad { 
             get {
              return this.OgrenciAd + this.OgrenciSoyad;
                  } 
           }
        [DisplayName("Öğrencinin Epostası")]
        public string? Eposta { get; set; }
        [DisplayName("Öğrencinin Telefonu")]
        public string? Telefon { get; set; }

        public ICollection<KursKayit> KursKayitlari {get; set;} = new List<KursKayit>();



    }
}