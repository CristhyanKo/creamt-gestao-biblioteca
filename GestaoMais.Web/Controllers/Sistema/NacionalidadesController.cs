using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoMais.Entities.Entities.Sistema;
using GestaoMais.Infrastructure.Configuration;

namespace GestaoMais.Web.Controllers.Sistema
{
    public class NacionalidadesController : Controller
    {
        private readonly ContextBase _context;

        public NacionalidadesController(ContextBase context)
        {
            _context = context;
        }

        // GET: Nacionalidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nacionalidade.ToListAsync());
        }

        // GET: Nacionalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.Nacionalidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nacionalidade == null)
            {
                return NotFound();
            }

            return View(nacionalidade);
        }

        // GET: Nacionalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nacionalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id")] Nacionalidade nacionalidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nacionalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nacionalidade);
        }

        // GET: Nacionalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.Nacionalidade.FindAsync(id);
            if (nacionalidade == null)
            {
                return NotFound();
            }
            return View(nacionalidade);
        }

        // POST: Nacionalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Id")] Nacionalidade nacionalidade)
        {
            if (id != nacionalidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nacionalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NacionalidadeExists(nacionalidade.Id))
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
            return View(nacionalidade);
        }

        // GET: Nacionalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.Nacionalidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nacionalidade == null)
            {
                return NotFound();
            }

            return View(nacionalidade);
        }

        // POST: Nacionalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nacionalidade = await _context.Nacionalidade.FindAsync(id);
            _context.Nacionalidade.Remove(nacionalidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NacionalidadeExists(int id)
        {
            return _context.Nacionalidade.Any(e => e.Id == id);
        }
    }
}
