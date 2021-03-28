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
    public class LivroesController : Controller
    {
        private readonly ILivro _context;

        public LivroesController(ILivro context)
        {
            _context = context;
        }

        // GET: Livroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Livroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.GetById((int)id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livroes/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList("Id", "Id");
            ViewData["CategoriaId"] = new SelectList("Id", "Nome");
            ViewData["EditoraId"] = new SelectList("Id", "Id");
            ViewData["LivroSituacaoId"] = new SelectList("Id", "Nome");
            return View();
        }

        // POST: Livroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN,Titulo,AutorId,EditoraId,Edicao,Ano,CategoriaId,LivroSituacaoId,Id")] Entities.Entities.Livro.Livro livro)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(livro);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(null, "Id", "Id", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(null, "Id", "Nome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(null, "Id", "Id", livro.EditoraId);
            ViewData["LivroSituacaoId"] = new SelectList(null, "Id", "Nome", livro.LivroSituacaoId);
            return View(livro);
        }

        // GET: Livroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.GetById((int)id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(null, "Id", "Id", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(null, "Id", "Nome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(null, "Id", "Id", livro.EditoraId);
            ViewData["LivroSituacaoId"] = new SelectList(null, "Id", "Nome", livro.LivroSituacaoId);
            return View(livro);
        }

        // POST: Livroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ISBN,Titulo,AutorId,EditoraId,Edicao,Ano,CategoriaId,LivroSituacaoId,Id")] Entities.Entities.Livro.Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(livro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LivroExists(livro.Id))
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
            ViewData["AutorId"] = new SelectList(null, "Id", "Id", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(null, "Id", "Nome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(null, "Id", "Id", livro.EditoraId);
            ViewData["LivroSituacaoId"] = new SelectList(null, "Id", "Nome", livro.LivroSituacaoId);
            return View(livro);
        }

        // GET: Livroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.GetById((int)id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.GetById(id);
            await _context.Delete(livro);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LivroExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
