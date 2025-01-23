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
    
    public class OgretmenController : Controller
    {
        private readonly DataContext _context ;
        public OgretmenController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult>  Index()
        {
      
            return View(await _context.Ogretmenler.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {

            if(ModelState.IsValid){

                _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

         return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if(id == null) {
                return NotFound();
            }

            var ogr = await _context.Ogretmenler.FirstOrDefaultAsync(o => o.OgretmenId == id);
            
            if(ogr == null) {
                return NotFound();
            }
            return View(model: ogr);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id,Ogretmen model)
        {

            if(id == null) {
                return NotFound();
            }

            if(ModelState.IsValid){
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
            }
            else {
                return View();
            }

          
        }

    }
}