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
    public class datos_personalesController : Controller
    {
        private readonly SistemaTutorInteligenteContext _context;

        public datos_personalesController(SistemaTutorInteligenteContext context)
        {
            _context = context;
        }

        // GET: datos_personales
        public async Task<IActionResult> Index()
        {
            var sistemaTutorInteligenteContext = _context.datos_personales.Include(d => d.datos_cuenta).Include(d => d.tipo_usuario);
            return View(await sistemaTutorInteligenteContext.ToListAsync());
        }

        // GET: datos_personales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos_personales = await _context.datos_personales
                .Include(d => d.datos_cuenta)
                .Include(d => d.tipo_usuario)
                .SingleOrDefaultAsync(m => m.id_datos == id);
            if (datos_personales == null)
            {
                return NotFound();
            }

            return View(datos_personales);
        }

        // GET: datos_personales/Create
        public IActionResult Create()
        {
            ViewData["id_usuario"] = new SelectList(_context.Set<datos_cuenta>(), "id_usuario", "id_usuario");
            ViewData["id_tipo"] = new SelectList(_context.Set<tipo_usuario>(), "id_tipo", "id_tipo");
            return View();
        }

        // POST: datos_personales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_datos,nombre,a_paterno,a_materno,edad,id_tipo,id_usuario")] datos_personales datos_personales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datos_personales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_usuario"] = new SelectList(_context.Set<datos_cuenta>(), "id_usuario", "id_usuario", datos_personales.id_usuario);
            ViewData["id_tipo"] = new SelectList(_context.Set<tipo_usuario>(), "id_tipo", "id_tipo", datos_personales.id_tipo);
            return View(datos_personales);
        }

        // GET: datos_personales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos_personales = await _context.datos_personales.SingleOrDefaultAsync(m => m.id_datos == id);
            if (datos_personales == null)
            {
                return NotFound();
            }
            ViewData["id_usuario"] = new SelectList(_context.Set<datos_cuenta>(), "id_usuario", "id_usuario", datos_personales.id_usuario);
            ViewData["id_tipo"] = new SelectList(_context.Set<tipo_usuario>(), "id_tipo", "id_tipo", datos_personales.id_tipo);
            return View(datos_personales);
        }

        // POST: datos_personales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_datos,nombre,a_paterno,a_materno,edad,id_tipo,id_usuario")] datos_personales datos_personales)
        {
            if (id != datos_personales.id_datos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datos_personales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!datos_personalesExists(datos_personales.id_datos))
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
            ViewData["id_usuario"] = new SelectList(_context.Set<datos_cuenta>(), "id_usuario", "id_usuario", datos_personales.id_usuario);
            ViewData["id_tipo"] = new SelectList(_context.Set<tipo_usuario>(), "id_tipo", "id_tipo", datos_personales.id_tipo);
            return View(datos_personales);
        }

        // GET: datos_personales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos_personales = await _context.datos_personales
                .Include(d => d.datos_cuenta)
                .Include(d => d.tipo_usuario)
                .SingleOrDefaultAsync(m => m.id_datos == id);
            if (datos_personales == null)
            {
                return NotFound();
            }

            return View(datos_personales);
        }

        // POST: datos_personales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datos_personales = await _context.datos_personales.SingleOrDefaultAsync(m => m.id_datos == id);
            _context.datos_personales.Remove(datos_personales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool datos_personalesExists(int id)
        {
            return _context.datos_personales.Any(e => e.id_datos == id);
        }
    }
}
