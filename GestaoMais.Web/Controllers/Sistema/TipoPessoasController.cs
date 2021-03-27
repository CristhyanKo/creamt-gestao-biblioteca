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
    public class TipoPessoasController : Controller
    {
        private readonly ContextBase _context;

        public TipoPessoasController(ContextBase context)
        {
            _context = context;
        }

        // GET: TipoPessoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPessoa.ToListAsync());
        }

        // GET: TipoPessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPessoa = await _context.TipoPessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPessoa == null)
            {
                return NotFound();
            }

            return View(tipoPessoa);
        }

        // GET: TipoPessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id")] TipoPessoa tipoPessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPessoa);
        }

        // GET: TipoPessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPessoa = await _context.TipoPessoa.FindAsync(id);
            if (tipoPessoa == null)
            {
                return NotFound();
            }
            return View(tipoPessoa);
        }

        // POST: TipoPessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Id")] TipoPessoa tipoPessoa)
        {
            if (id != tipoPessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPessoaExists(tipoPessoa.Id))
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
            return View(tipoPessoa);
        }

        // GET: TipoPessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPessoa = await _context.TipoPessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPessoa == null)
            {
                return NotFound();
            }

            return View(tipoPessoa);
        }

        // POST: TipoPessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPessoa = await _context.TipoPessoa.FindAsync(id);
            _context.TipoPessoa.Remove(tipoPessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPessoaExists(int id)
        {
            return _context.TipoPessoa.Any(e => e.Id == id);
        }
    }
}
