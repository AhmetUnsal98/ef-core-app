using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ef_core_app.Data;
using ef_core_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace ef_core_app.Controllers
{

    public class KursController : Controller
    {
    
        private readonly DataContext _context;
        public KursController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
          
            return View(model: await _context.Kurslar.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create() {
            
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(),"OgretmenId","OgretmenAd");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kurs model) {
            
            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Kurs");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id ) {
            
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(),"OgretmenId","OgretmenAd");
   
            var kurs = await _context.Kurslar.Include(k => k.KursKayitlari).ThenInclude(k => k.Ogrenci).Select(k => new KursViewModel 
                    {  KursId = k.KursId,
                Baslik = k.Baslik,
                OgretmenId = k.OgretmenId,
                KursKayitlari = k.KursKayitlari }).FirstOrDefaultAsync(i => i.KursId == id);
            if(kurs == null) {
                return NotFound();
            }
            return View(model: kurs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KursViewModel model) {
            
            if(ModelState.IsValid){
                _context.Update(new Kurs(){KursId = model.KursId , Baslik= model.Baslik , OgretmenId = model.OgretmenId});
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }else {
                return NotFound();
            }

         
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id){
            if(id == null) {
                return NotFound();
            }
            return View(model: await _context.Kurslar.FindAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id){
            
            if(id == null ){
                return NotFound();
            }
            var kurs =  _context.Kurslar.Find(id);
            _context.Kurslar.Remove(kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}