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
    public class NegociosController : Controller
    {
        private readonly NegociosLlamadasContext _context;

        public NegociosController(NegociosLlamadasContext context)
        {
            _context = context;
        }

        // GET: Negocios
        public async Task<IActionResult> Index()
        {
            var negocio = from m in _context.Negocios
                          select m;

            //var tllamadas = (from c in _context.Llamadas where c.IdNegocio).Count();
            var listaNegocios = (from m in _context.Negocios
                          select m).ToList();
            List<ViewModelNegocioTotal> NegociosToView = new List<ViewModelNegocioTotal>();

            foreach(var negoco in listaNegocios)
            {
                int tllamadas = _context.Llamadas.Where(x => x.IdNegocio == negoco.IdNegocio).Count();

                NegociosToView.Add(new ViewModelNegocioTotal
                {
                    Contacto = negoco.Contacto,
                    Direccion = negoco.Direccion,
                    TotalLlamadas = tllamadas,
                    Negocio = negoco.Negocio,
                    Telefono = negoco.Telefono,
                    IdNegocio = negoco.IdNegocio
                    //NegociosList = await negocio.ToListAsync()
                });

            }


            //var NegocioLlamdas =
            //    from negocios in _context.Negocios
            //    join llamadas in _context.Llamadas on negocios.IdNegocio equals llamadas.IdNegocio
            //select new ViewModelNegocioTotal {
            //    Negocio = negocios.Negocio,
            //    Direccion = negocios.Direccion,
            //    Contacto = negocios.Contacto,
            //    Telefono = negocios.Telefono,
            //    TotalLlamadas = llamadas
                

            //};

            //var nego = new ViewModelNegocioTotal
            //{
            //    Negocios = await negocio.ToListAsync(),
            //    TotalLlamadas = from f 
            //};

            return View(NegociosToView);
        }

        // GET: Negocios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocios = await _context.Negocios
                .FirstOrDefaultAsync(m => m.IdNegocio == id);
            if (negocios == null)
            {
                return NotFound();
            }

            return View(negocios);
        }

        // GET: Negocios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Negocios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNegocio,Negocio,Direccion,Contacto,Telefono")] Negocios negocios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(negocios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(negocios);
        }

        // GET: Negocios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocios = await _context.Negocios.FindAsync(id);
            if (negocios == null)
            {
                return NotFound();
            }
            return View(negocios);
        }

        // POST: Negocios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNegocio,Negocio,Direccion,Contacto,Telefono")] Negocios negocios)
        {
            if (id != negocios.IdNegocio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(negocios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NegociosExists(negocios.IdNegocio))
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
            return View(negocios);
        }

        // GET: Negocios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocios = await _context.Negocios
                .FirstOrDefaultAsync(m => m.IdNegocio == id);
            if (negocios == null)
            {
                return NotFound();
            }

            return View(negocios);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var negocios = await _context.Negocios.FindAsync(id);
            _context.Negocios.Remove(negocios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NegociosExists(int id)
        {
            return _context.Negocios.Any(e => e.IdNegocio == id);
        }
    }
}
