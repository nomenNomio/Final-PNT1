using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Models;
using ProyectoFinal.BDhelper;

namespace ProyectoFinal.Controllers
{
    public class RefugioController : Controller
    {
        private readonly ProyectoFinalDatabaseContext _context;

        public RefugioController(ProyectoFinalDatabaseContext context)
        {
            _context = context;
        }

        // GET: Refugio
        public async Task<IActionResult> Index()
        {
              return _context.Refugios != null ? 
                          View(await _context.Refugios.ToListAsync()) :
                          Problem("Entity set 'ProyectoFinalDatabaseContext.Refugios'  is null.");
        }
        public async Task<IActionResult> CrearRefugio(String nom, String des, String dir, String hor, IFormFile ImageData)
        {
            Refugio refu = await BDhelp.CrearRefugio(nom, des, dir, hor, ImageData, _context);


            return View(refu);

        }

        public async Task<IActionResult> UnRefugio(String refugioID) {

            Refugio refugio = _context.Refugios.Where(r => r.Id == int.Parse(refugioID))
                .Include(r => r.Mascotas)
                .FirstOrDefault();
                
            return refugio != null ?
                View(refugio) :
                Problem("Entity set 'ProyectoFinalDatabaseContext.Refugio'  is null.");
        }

        // GET: Refugio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Refugios == null)
            {
                return NotFound();
            }

            var refugio = await _context.Refugios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refugio == null)
            {
                return NotFound();
            }

            return View(refugio);
        }

        // GET: Refugio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refugio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,direccion,Horario")] Refugio refugio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refugio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refugio);
        }

        // GET: Refugio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Refugios == null)
            {
                return NotFound();
            }

            var refugio = await _context.Refugios.FindAsync(id);
            if (refugio == null)
            {
                return NotFound();
            }
            return View(refugio);
        }

        // POST: Refugio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,direccion,Horario")] Refugio refugio)
        {
            if (id != refugio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refugio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefugioExists(refugio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(refugio);
        }

        // GET: Refugio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Refugios == null)
            {
                return NotFound();
            }

            var refugio = await _context.Refugios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refugio == null)
            {
                return NotFound();
            }

            return View(refugio);
        }

        // POST: Refugio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Refugios == null)
            {
                return Problem("Entity set 'ProyectoFinalDatabaseContext.Refugios'  is null.");
            }
            var refugio = await _context.Refugios.FindAsync(id);
            if (refugio != null)
            {
                _context.Refugios.Remove(refugio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefugioExists(int id)
        {
          return (_context.Refugios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
