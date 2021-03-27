using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoMais.Entities.Entities.Livro;
using GestaoMais.Infrastructure.Configuration;

namespace GestaoMais.Web.Controllers.Livro
{
    public class LivroSituacaosController : Controller
    {
        private readonly ContextBase _context;

        public LivroSituacaosController(ContextBase context)
        {
            _context = context;
        }

        // GET: LivroSituacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.LivroSituacao.ToListAsync());
        }

        // GET: LivroSituacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroSituacao = await _context.LivroSituacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livroSituacao == null)
            {
                return NotFound();
            }

            return View(livroSituacao);
        }

        // GET: LivroSituacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LivroSituacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id")] LivroSituacao livroSituacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livroSituacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livroSituacao);
        }

        // GET: LivroSituacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroSituacao = await _context.LivroSituacao.FindAsync(id);
            if (livroSituacao == null)
            {
                return NotFound();
            }
            return View(livroSituacao);
        }

        // POST: LivroSituacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Id")] LivroSituacao livroSituacao)
        {
            if (id != livroSituacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livroSituacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroSituacaoExists(livroSituacao.Id))
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
            return View(livroSituacao);
        }

        // GET: LivroSituacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroSituacao = await _context.LivroSituacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livroSituacao == null)
            {
                return NotFound();
            }

            return View(livroSituacao);
        }

        // POST: LivroSituacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livroSituacao = await _context.LivroSituacao.FindAsync(id);
            _context.LivroSituacao.Remove(livroSituacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroSituacaoExists(int id)
        {
            return _context.LivroSituacao.Any(e => e.Id == id);
        }
    }
}
