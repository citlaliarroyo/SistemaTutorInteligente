using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTutorInteligente.Models;

namespace SistemaTutorInteligente.Controllers
{
    public class datos_cuentaController : Controller
    {
        private readonly SistemaTutorInteligenteContext _context;

        public datos_cuentaController(SistemaTutorInteligenteContext context)
        {
            _context = context;
        }

        // GET: datos_cuenta
        public async Task<IActionResult> Index()
        {
            return View(await _context.datos_cuenta.ToListAsync());
        }

        // GET: datos_cuenta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos_cuenta = await _context.datos_cuenta
                .SingleOrDefaultAsync(m => m.id_usuario == id);
            if (datos_cuenta == null)
            {
                return NotFound();
            }

            return View(datos_cuenta);
        }

        // GET: datos_cuenta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: datos_cuenta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_usuario,usuario,password")] datos_cuenta datos_cuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datos_cuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datos_cuenta);
        }

        // GET: datos_cuenta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos_cuenta = await _context.datos_cuenta.SingleOrDefaultAsync(m => m.id_usuario == id);
            if (datos_cuenta == null)
            {
                return NotFound();
            }
            return View(datos_cuenta);
        }

        // POST: datos_cuenta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_usuario,usuario,password")] datos_cuenta datos_cuenta)
        {
            if (id != datos_cuenta.id_usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datos_cuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!datos_cuentaExists(datos_cuenta.id_usuario))
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
            return View(datos_cuenta);
        }

        // GET: datos_cuenta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos_cuenta = await _context.datos_cuenta
                .SingleOrDefaultAsync(m => m.id_usuario == id);
            if (datos_cuenta == null)
            {
                return NotFound();
            }

            return View(datos_cuenta);
        }

        // POST: datos_cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datos_cuenta = await _context.datos_cuenta.SingleOrDefaultAsync(m => m.id_usuario == id);
            _context.datos_cuenta.Remove(datos_cuenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool datos_cuentaExists(int id)
        {
            return _context.datos_cuenta.Any(e => e.id_usuario == id);
        }
    }
}
