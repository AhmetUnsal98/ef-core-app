using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_app.Data
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenId { get; set; }
        [DisplayName("Öğretmenin Adı")]
        public string OgretmenAd { get; set; }
        [DisplayName("Öğretmenin Soyadı")]
        public string OgretmenSoyad { get; set; }

        public ICollection<Kurs> OgretmenKurslar { get; set; } = new List<Kurs>();
    }
}