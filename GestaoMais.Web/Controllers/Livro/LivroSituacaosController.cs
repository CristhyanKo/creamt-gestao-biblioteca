using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoMais.Entities.Entities.Livro;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Application.Interfaces.Livro;

namespace GestaoMais.Web.Controllers.Livro
{
    public class LivroSituacaosController : Controller
    {
        private readonly ILivroSituacao _context;

        public LivroSituacaosController(ILivroSituacao context)
        {
            _context = context;
        }

        // GET: LivroSituacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: LivroSituacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroSituacao = await _context.GetById((int)id);
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
                await _context.Add(livroSituacao);
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

            var livroSituacao = await _context.GetById((int)id);
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
                    await _context.Update(livroSituacao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LivroSituacaoExists(livroSituacao.Id))
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

            var livroSituacao = await _context.GetById((int)id);
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
            var livroSituacao = await _context.GetById(id);
            await _context.Delete(livroSituacao);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LivroSituacaoExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
