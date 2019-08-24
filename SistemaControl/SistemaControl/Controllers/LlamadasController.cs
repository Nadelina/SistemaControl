using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaControl.Models;

namespace SistemaControl.Controllers
{
    public class LlamadasController : Controller
    {
        private readonly NegociosLlamadasContext _context;

        public LlamadasController(NegociosLlamadasContext context)
        {
            _context = context;
        }

        // GET: Llamadas
        public async Task<IActionResult> Index()
        {
            var negociosLlamadasContext = _context.Llamadas.Include(l => l.IdNegocioNavigation);
            return View(await negociosLlamadasContext.ToListAsync());
        }

        // GET: Llamadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llamadas = await _context.Llamadas
                .Include(l => l.IdNegocioNavigation)
                .FirstOrDefaultAsync(m => m.IdLlamadas == id);
            if (llamadas == null)
            {
                return NotFound();
            }

            return View(llamadas);
        }

        // GET: Llamadas/Create
        public IActionResult Create()
        {
            ViewData["IdNegocio"] = new SelectList(_context.Negocios, "IdNegocio", "Contacto");
            return View();
        }

        // POST: Llamadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLlamadas,IdNegocio,FechaHora")] Llamadas llamadas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(llamadas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNegocio"] = new SelectList(_context.Negocios, "IdNegocio", "Contacto", llamadas.IdNegocio);
            return View(llamadas);
        }
        public  IActionResult CreateD(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.dato = id;
            
            return View();            

        }

        // POST: Llamadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateD([Bind("IdLlamadas,IdNegocio,FechaHora")] Llamadas llamadas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(llamadas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNegocio"] = new SelectList(_context.Negocios, "IdNegocio", "Contacto", llamadas.IdNegocio);
            return View(llamadas);
        }
        // GET: Llamadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llamadas = await _context.Llamadas.FindAsync(id);
            if (llamadas == null)
            {
                return NotFound();
            }
            ViewData["IdNegocio"] = new SelectList(_context.Negocios, "IdNegocio", "Contacto", llamadas.IdNegocio);
            return View(llamadas);
        }

        // POST: Llamadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLlamadas,IdNegocio,FechaHora")] Llamadas llamadas)
        {
            if (id != llamadas.IdLlamadas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(llamadas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LlamadasExists(llamadas.IdLlamadas))
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
            ViewData["IdNegocio"] = new SelectList(_context.Negocios, "IdNegocio", "Contacto", llamadas.IdNegocio);
            return View(llamadas);
        }

        // GET: Llamadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llamadas = await _context.Llamadas
                .Include(l => l.IdNegocioNavigation)
                .FirstOrDefaultAsync(m => m.IdLlamadas == id);
            if (llamadas == null)
            {
                return NotFound();
            }

            return View(llamadas);
        }

        // POST: Llamadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var llamadas = await _context.Llamadas.FindAsync(id);
            _context.Llamadas.Remove(llamadas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LlamadasExists(int id)
        {
            return _context.Llamadas.Any(e => e.IdLlamadas == id);
        }
    }
}
