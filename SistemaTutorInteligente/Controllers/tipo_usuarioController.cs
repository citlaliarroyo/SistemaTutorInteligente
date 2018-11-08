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
    public class tipo_usuarioController : Controller
    {
        private readonly SistemaTutorInteligenteContext _context;

        public tipo_usuarioController(SistemaTutorInteligenteContext context)
        {
            _context = context;
        }

        // GET: tipo_usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.tipo_usuario.ToListAsync());
        }

        // GET: tipo_usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_usuario = await _context.tipo_usuario
                .SingleOrDefaultAsync(m => m.id_tipo == id);
            if (tipo_usuario == null)
            {
                return NotFound();
            }

            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tipo_usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tipo,nombre_tipo_usuario")] tipo_usuario tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_usuario = await _context.tipo_usuario.SingleOrDefaultAsync(m => m.id_tipo == id);
            if (tipo_usuario == null)
            {
                return NotFound();
            }
            return View(tipo_usuario);
        }

        // POST: tipo_usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tipo,nombre_tipo_usuario")] tipo_usuario tipo_usuario)
        {
            if (id != tipo_usuario.id_tipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tipo_usuarioExists(tipo_usuario.id_tipo))
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
            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_usuario = await _context.tipo_usuario
                .SingleOrDefaultAsync(m => m.id_tipo == id);
            if (tipo_usuario == null)
            {
                return NotFound();
            }

            return View(tipo_usuario);
        }

        // POST: tipo_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipo_usuario = await _context.tipo_usuario.SingleOrDefaultAsync(m => m.id_tipo == id);
            _context.tipo_usuario.Remove(tipo_usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tipo_usuarioExists(int id)
        {
            return _context.tipo_usuario.Any(e => e.id_tipo == id);
        }
    }
}
