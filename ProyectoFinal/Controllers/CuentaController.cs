using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProyectoFinal.Context;
using ProyectoFinal.Models;
using ProyectoFinal.BDhelper;
using NuGet.Protocol;

namespace ProyectoFinal.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ProyectoFinalDatabaseContext _context;

        public CuentaController(ProyectoFinalDatabaseContext context)
        {
            _context = context;
        }

        // GET: Cuenta
        public async Task<IActionResult> Index()
        {
              return _context.Cuentas != null ? 
                          View(await _context.Cuentas.ToListAsync()) :
                          Problem("Entity set 'ProyectoFinalDatabaseContext.Cuentas'  is null.");
        }

        public async Task<IActionResult> Login()
        {
            return _context.Cuentas != null ?
                        View(await _context.Cuentas.ToListAsync()) :
                        Problem("Entity set 'ProyectoFinalDatabaseContext.Cuentas'  is null.");
        }

        public async Task<IActionResult> Register()
        {
            return _context.Cuentas != null ?
                        View(await _context.Cuentas.ToListAsync()) :
                        Problem("Entity set 'ProyectoFinalDatabaseContext.Cuentas'  is null.");
        }

        public async Task<IActionResult> Registrarse(String usr, String pwd, String eml)
        {
            if (await BDhelp.Crear(usr, pwd, eml, _context))
            {
                return RedirectToAction("Index", "Mascota");
            }
            else {
                return RedirectToAction("Register", "Cuenta");
            }
        }

        public async Task<IActionResult> Loguearse(String usr, String pwd)
        {
            Cuenta resultado = await BDhelp.Loguear(usr, pwd, _context);

            if (resultado!=null) {
                HttpContext.Session.SetString("Nombre", resultado.Nombre);
                HttpContext.Session.SetString("Email", resultado.Email);
                HttpContext.Session.SetString("password", resultado.Password);
                HttpContext.Session.SetInt32("admin", resultado.Admin ? 1 : 0);

            }

            return resultado == null ?  RedirectToAction("Login", "Cuenta") : RedirectToAction("Index", "Mascota");
        }

        // GET: Cuenta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cuentas == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // GET: Cuenta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuenta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Password,Email,Admin")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cuenta);
        }

        // GET: Cuenta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cuentas == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuentas.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return View(cuenta);
        }

        // POST: Cuenta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Password,Email,Admin")] Cuenta cuenta)
        {
            if (id != cuenta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentaExists(cuenta.Id))
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
            return View(cuenta);
        }

        // GET: Cuenta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cuentas == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // POST: Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cuentas == null)
            {
                return Problem("Entity set 'ProyectoFinalDatabaseContext.Cuentas'  is null.");
            }
            var cuenta = await _context.Cuentas.FindAsync(id);
            if (cuenta != null)
            {
                _context.Cuentas.Remove(cuenta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentaExists(int id)
        {
          return (_context.Cuentas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
