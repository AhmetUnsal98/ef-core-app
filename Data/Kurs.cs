using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_app.Data
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        [DisplayName("Kurs Adi")]
        public string? Baslik { get; set; }

        public ICollection<KursKayit> KursKayitlari {get; set;} = new List<KursKayit>();

        public int? OgretmenId { get; set; }

        public Ogretmen Ogretmen {get; set;}

    }
}