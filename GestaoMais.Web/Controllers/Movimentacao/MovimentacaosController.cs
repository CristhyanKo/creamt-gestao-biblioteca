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
    public class MovimentacaosController : Controller
    {
        private readonly ContextBase _context;

        public MovimentacaosController(ContextBase context)
        {
            _context = context;
        }

        // GET: Movimentacaos
        public async Task<IActionResult> Index()
        {
            var contextBase = _context.Movimentacao.Include(m => m.Funcionario).Include(m => m.Livro).Include(m => m.MovimentacaoSituacao).Include(m => m.Pessoa);
            return View(await contextBase.ToListAsync());
        }

        // GET: Movimentacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao
                .Include(m => m.Funcionario)
                .Include(m => m.Livro)
                .Include(m => m.MovimentacaoSituacao)
                .Include(m => m.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: Movimentacaos/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id");
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Edicao");
            ViewData["MovimentacaoSituacaoId"] = new SelectList(_context.MovimentacaoSituacao, "Id", "Nome");
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial");
            return View();
        }

        // POST: Movimentacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LivroId,PessoaId,FuncionarioId,EmprestimoLocal,DataEmprestimo,DataLimiteDevolucao,DataDevolucao,MovimentacaoSituacaoId,Id,DataCriacao")] Entities.Entities.Movimentacao.Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id", movimentacao.FuncionarioId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Edicao", movimentacao.LivroId);
            ViewData["MovimentacaoSituacaoId"] = new SelectList(_context.MovimentacaoSituacao, "Id", "Nome", movimentacao.MovimentacaoSituacaoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", movimentacao.PessoaId);
            return View(movimentacao);
        }

        // GET: Movimentacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao.FindAsync(id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id", movimentacao.FuncionarioId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Edicao", movimentacao.LivroId);
            ViewData["MovimentacaoSituacaoId"] = new SelectList(_context.MovimentacaoSituacao, "Id", "Nome", movimentacao.MovimentacaoSituacaoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", movimentacao.PessoaId);
            return View(movimentacao);
        }

        // POST: Movimentacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LivroId,PessoaId,FuncionarioId,EmprestimoLocal,DataEmprestimo,DataLimiteDevolucao,DataDevolucao,MovimentacaoSituacaoId,Id,DataCriacao")] Entities.Entities.Movimentacao.Movimentacao movimentacao)
        {
            if (id != movimentacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoExists(movimentacao.Id))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id", movimentacao.FuncionarioId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Edicao", movimentacao.LivroId);
            ViewData["MovimentacaoSituacaoId"] = new SelectList(_context.MovimentacaoSituacao, "Id", "Nome", movimentacao.MovimentacaoSituacaoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", movimentacao.PessoaId);
            return View(movimentacao);
        }

        // GET: Movimentacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao
                .Include(m => m.Funcionario)
                .Include(m => m.Livro)
                .Include(m => m.MovimentacaoSituacao)
                .Include(m => m.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: Movimentacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacao = await _context.Movimentacao.FindAsync(id);
            _context.Movimentacao.Remove(movimentacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoExists(int id)
        {
            return _context.Movimentacao.Any(e => e.Id == id);
        }
    }
}
