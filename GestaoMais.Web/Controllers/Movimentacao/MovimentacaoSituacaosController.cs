using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoMais.Entities.Entities.Movimentacao;
using GestaoMais.Infrastructure.Configuration;

namespace GestaoMais.Web.Controllers.Movimentacao
{
    public class MovimentacaoSituacaosController : Controller
    {
        private readonly ContextBase _context;

        public MovimentacaoSituacaosController(ContextBase context)
        {
            _context = context;
        }

        // GET: MovimentacaoSituacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovimentacaoSituacao.ToListAsync());
        }

        // GET: MovimentacaoSituacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoSituacao = await _context.MovimentacaoSituacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacaoSituacao == null)
            {
                return NotFound();
            }

            return View(movimentacaoSituacao);
        }

        // GET: MovimentacaoSituacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovimentacaoSituacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id")] MovimentacaoSituacao movimentacaoSituacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacaoSituacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movimentacaoSituacao);
        }

        // GET: MovimentacaoSituacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoSituacao = await _context.MovimentacaoSituacao.FindAsync(id);
            if (movimentacaoSituacao == null)
            {
                return NotFound();
            }
            return View(movimentacaoSituacao);
        }

        // POST: MovimentacaoSituacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Id")] MovimentacaoSituacao movimentacaoSituacao)
        {
            if (id != movimentacaoSituacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacaoSituacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoSituacaoExists(movimentacaoSituacao.Id))
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
            return View(movimentacaoSituacao);
        }

        // GET: MovimentacaoSituacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoSituacao = await _context.MovimentacaoSituacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacaoSituacao == null)
            {
                return NotFound();
            }

            return View(movimentacaoSituacao);
        }

        // POST: MovimentacaoSituacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacaoSituacao = await _context.MovimentacaoSituacao.FindAsync(id);
            _context.MovimentacaoSituacao.Remove(movimentacaoSituacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoSituacaoExists(int id)
        {
            return _context.MovimentacaoSituacao.Any(e => e.Id == id);
        }
    }
}
