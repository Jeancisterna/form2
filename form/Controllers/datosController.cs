using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using form.Data;

namespace form.Controllers
{
    public class datosController : Controller
    {
        private readonly formContext _context;

        public datosController(formContext context)
        {
            _context = context;
        }

        // GET: datos
        public async Task<IActionResult> Index()
        {
              return View(await _context.datos.ToListAsync());
        }

        // GET: datos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.datos == null)
            {
                return NotFound();
            }

            var datos = await _context.datos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (datos == null)
            {
                return NotFound();
            }

            return View(datos);
        }

        // GET: datos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: datos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombres,Apellidos")] datos datos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datos);
        }

        // GET: datos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.datos == null)
            {
                return NotFound();
            }

            var datos = await _context.datos.FindAsync(id);
            if (datos == null)
            {
                return NotFound();
            }
            return View(datos);
        }

        // POST: datos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombres,Apellidos")] datos datos)
        {
            if (id != datos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!datosExists(datos.ID))
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
            return View(datos);
        }

        // GET: datos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.datos == null)
            {
                return NotFound();
            }

            var datos = await _context.datos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (datos == null)
            {
                return NotFound();
            }

            return View(datos);
        }

        // POST: datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.datos == null)
            {
                return Problem("Entity set 'formContext.datos'  is null.");
            }
            var datos = await _context.datos.FindAsync(id);
            if (datos != null)
            {
                _context.datos.Remove(datos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool datosExists(int id)
        {
          return _context.datos.Any(e => e.ID == id);
        }
    }
}
