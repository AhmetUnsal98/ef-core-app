using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ef_core_app.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef_core_app.Controllers
{

    public class OgrenciController : Controller
    {
  
        private readonly DataContext _context ; 
        public OgrenciController(DataContext context)
        {
            _context = context;   
        }
        public async Task<IActionResult> Index()
        {
            
            return View(model: await _context.Ogrenciler.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {   
            
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Ogrenci");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if(id == null) {
                return NotFound();
            }

            var ogr = await _context.Ogrenciler.Include(o => o.KursKayitlari).ThenInclude(o => o.Kurs).FirstOrDefaultAsync(o => o.OgrenciId == id);
            
            if(ogr == null) {
                return NotFound();
            }
            return View(model: ogr);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int? id ,Ogrenci model)
        {   
            if(id != model.OgrenciId) {
                return NotFound();
            }

       

            if(ModelState.IsValid) {

                    try
                    {
                        _context.Update(model);
                        await _context.SaveChangesAsync();
                    }
                    catch (System.Exception)
                    {
                        
                        if(!_context.Ogrenciler.Any(o => o.OgrenciId == model.OgrenciId)){
                            return NotFound();
                        }
                    }
            return RedirectToAction("Index","Ogrenci");

            } else {

                return View();

            }

 


    
    
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id) {
            if(id == null) {
                return NotFound();
            } 
            var ogrenci = await _context.Ogrenciler.FirstOrDefaultAsync(i => i.OgrenciId == id);

            if(ogrenci == null) {
                return NotFound();
            }
            return View(model: ogrenci);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id) {
    
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if(ogrenci == null) {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            

            return RedirectToAction("Index");
        }

    }
}