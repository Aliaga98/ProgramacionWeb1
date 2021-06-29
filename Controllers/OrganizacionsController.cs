using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Login_Proyecto.Models;

namespace Login_Proyecto.Controllers
{
    public class OrganizacionsController : Controller
    {
        private readonly Voluntariado_Santa_cruzContext _context;

        public OrganizacionsController(Voluntariado_Santa_cruzContext context)
        {
            _context = context;
        }

        // GET: Organizacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organizacion.ToListAsync());
        }

        // GET: Organizacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizacion = await _context.Organizacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizacion == null)
            {
                return NotFound();
            }

            return View(organizacion);
        }

        // GET: Organizacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Usuario,Clave,Rol,Telefono,Descripcion,Socios,Departamento,Sede")] Organizacion organizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizacion);
        }

        // GET: Organizacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizacion = await _context.Organizacion.FindAsync(id);
            if (organizacion == null)
            {
                return NotFound();
            }
            return View(organizacion);
        }

        // POST: Organizacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Usuario,Clave,Rol,Telefono,Descripcion,Socios,Departamento,Sede")] Organizacion organizacion)
        {
            if (id != organizacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizacionExists(organizacion.Id))
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
            return View(organizacion);
        }

        // GET: Organizacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizacion = await _context.Organizacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizacion == null)
            {
                return NotFound();
            }

            return View(organizacion);
        }

        // POST: Organizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizacion = await _context.Organizacion.FindAsync(id);
            _context.Organizacion.Remove(organizacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizacionExists(int id)
        {
            return _context.Organizacion.Any(e => e.Id == id);
        }
    }
}
