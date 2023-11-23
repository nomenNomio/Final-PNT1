using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Models;
using System.Web;
using ProyectoFinal.BDhelper;


namespace ProyectoFinal.Controllers
{
    public class MascotaController : Controller
    {
        private readonly ProyectoFinalDatabaseContext _context;

        public MascotaController(ProyectoFinalDatabaseContext context)
        {
            _context = context;
        }

        // GET: Mascota
        public async Task<IActionResult> Index()
        {
              return _context.Mascotas != null ? 
                          View(await _context.Mascotas.ToListAsync()) :
                          Problem("Entity set 'ProyectoFinalDatabaseContext.Mascotas'  is null.");
        }

        public async Task<IActionResult> UnaMascota(String idMascota) {

            Mascota mascota = _context.Mascotas.Where(m => m.Id == int.Parse(idMascota))
                                .Include(r => r.SuRefugio)
                                .FirstOrDefault();

            return mascota != null ?
            View(mascota) :
            Problem("Entity set 'ProyectoFinalDatabaseContext.Mascotas'  is null.");

        }

        public async Task<IActionResult> CrearMascota(
            String idRefugio,
            String nom,
            String pers,
            String salud,
            int edad,
            int cantDue,
            int peso,
            bool vac,
            IFormFile ImageData
            )
        {
            if(nom != null && pers != null && pers != null && salud != null){
                await BDhelp.CrearMascota(idRefugio,nom,pers,salud,edad, cantDue,peso,vac, ImageData,_context);
            }
            Refugio refugio = await _context.Refugios.FirstOrDefaultAsync(refu => refu.Id == int.Parse(idRefugio));
            ViewData["RefugioId"] = refugio.Id.ToString();
            ViewData["RefugioNombre"] = refugio.Nombre;

            return View();

        }

        // GET: Mascota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mascotas == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // GET: Mascota/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mascota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Personalidad,EstadoDeSalud,Edad,CantDuenios,Peso,Vacunado")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }

        // GET: Mascota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mascotas == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            return View(mascota);
        }

        // POST: Mascota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Personalidad,EstadoDeSalud,Edad,CantDuenios,Peso,Vacunado")] Mascota mascota)
        {
            if (id != mascota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(mascota.Id))
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
            return View(mascota);
        }

        // GET: Mascota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mascotas == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // POST: Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mascotas == null)
            {
                return Problem("Entity set 'ProyectoFinalDatabaseContext.Mascotas'  is null.");
            }
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota != null)
            {
                _context.Mascotas.Remove(mascota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaExists(int id)
        {
          return (_context.Mascotas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
