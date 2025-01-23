using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ef_core_app.Data;

namespace ef_core_app.Models
{
    public class KursViewModel
    {
        [Key]
        public int KursId { get; set; }
        [DisplayName("Kurs Adi")]
        public string? Baslik { get; set; }

        public ICollection<KursKayit> KursKayitlari {get; set;} = new List<KursKayit>();

        public int? OgretmenId { get; set; }

    }
}