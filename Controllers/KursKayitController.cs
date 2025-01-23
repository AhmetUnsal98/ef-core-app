using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ef_core_app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef_core_app.Controllers
{
 
    public class KursKayitController : Controller
    {
     
        private readonly DataContext _context;
        public KursKayitController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(){

            var kursKayitlari = await _context.Kayitlar.Include(x => x.Ogrenci).Include(x => x.Kurs).ToListAsync();

            return View(model: kursKayitlari);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {   
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(),"KursId","Baslik");
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(),"OgrenciId","AdSoyad");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(KursKayit model)
        {   
            model.KayitTarihi = DateTime.Now;
            _context.Kayitlar.Add(model);
            await _context.SaveChangesAsync();

            return View();
        }



    }
}