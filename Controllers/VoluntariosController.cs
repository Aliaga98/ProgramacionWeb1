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
    public class VoluntariosController : Controller
    {
        private readonly Voluntariado_Santa_cruzContext _context;

        public VoluntariosController(Voluntariado_Santa_cruzContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }



        // GET: Voluntarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voluntario.ToListAsync());
        }

        // GET: Voluntarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        // GET: Voluntarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voluntarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ci,Nombre,Apellido,Usuario,Clave,Rol,Telefono,Departamento,Direccion,TelefonoEmergencia")] Voluntario voluntario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voluntario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(voluntario);
        }

        // GET: Voluntarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntario.FindAsync(id);
            if (voluntario == null)
            {
                return NotFound();
            }
            return View(voluntario);
        }

        // POST: Voluntarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ci,Nombre,Apellido,Usuario,Clave,Rol,Telefono,Departamento,Direccion,TelefonoEmergencia")] Voluntario voluntario)
        {
            if (id != voluntario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoluntarioExists(voluntario.Id))
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
            return View(voluntario);
        }

        // GET: Voluntarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        // POST: Voluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voluntario = await _context.Voluntario.FindAsync(id);
            _context.Voluntario.Remove(voluntario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoluntarioExists(int id)
        {
            return _context.Voluntario.Any(e => e.Id == id);
        }
    }
}
