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
    public class LivroesController : Controller
    {
        private readonly ContextBase _context;

        public LivroesController(ContextBase context)
        {
            _context = context;
        }

        // GET: Livroes
        public async Task<IActionResult> Index()
        {
            var contextBase = _context.Livro.Include(l => l.Autor).Include(l => l.Categoria).Include(l => l.Editora).Include(l => l.LivroSituacao);
            return View(await contextBase.ToListAsync());
        }

        // GET: Livroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .Include(l => l.Editora)
                .Include(l => l.LivroSituacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livroes/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id");
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome");
            ViewData["EditoraId"] = new SelectList(_context.Editora, "Id", "Id");
            ViewData["LivroSituacaoId"] = new SelectList(_context.LivroSituacao, "Id", "Nome");
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
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(_context.Editora, "Id", "Id", livro.EditoraId);
            ViewData["LivroSituacaoId"] = new SelectList(_context.LivroSituacao, "Id", "Nome", livro.LivroSituacaoId);
            return View(livro);
        }

        // GET: Livroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(_context.Editora, "Id", "Id", livro.EditoraId);
            ViewData["LivroSituacaoId"] = new SelectList(_context.LivroSituacao, "Id", "Nome", livro.LivroSituacaoId);
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
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id", livro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", livro.CategoriaId);
            ViewData["EditoraId"] = new SelectList(_context.Editora, "Id", "Id", livro.EditoraId);
            ViewData["LivroSituacaoId"] = new SelectList(_context.LivroSituacao, "Id", "Nome", livro.LivroSituacaoId);
            return View(livro);
        }

        // GET: Livroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .Include(l => l.Editora)
                .Include(l => l.LivroSituacao)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var livro = await _context.Livro.FindAsync(id);
            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.Id == id);
        }
    }
}
