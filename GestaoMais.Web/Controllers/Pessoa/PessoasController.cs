using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoMais.Entities.Entities.Pessoa;
using GestaoMais.Infrastructure.Configuration;

namespace GestaoMais.Web.Controllers.Pessoa
{
    public class PessoasController : Controller
    {
        private readonly ContextBase _context;

        public PessoasController(ContextBase context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            var contextBase = _context.Pessoa.Include(p => p.Nacionalidade).Include(p => p.Sexo).Include(p => p.TipoPessoa);
            return View(await contextBase.ToListAsync());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .Include(p => p.Nacionalidade)
                .Include(p => p.Sexo)
                .Include(p => p.TipoPessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            ViewData["NacionalidadeId"] = new SelectList(_context.Nacionalidade, "Id", "Descricao");
            ViewData["SexoId"] = new SelectList(_context.Sexo, "Id", "Descricao");
            ViewData["TipoPessoaId"] = new SelectList(_context.TipoPessoa, "Id", "Descricao");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeFantasia,RazaoSocial,CpfCnpj,Rg,DataNascimento,NacionalidadeId,SexoId,TipoPessoaId,Ativo,Id,DataCriacao")] Entities.Entities.Pessoa.Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NacionalidadeId"] = new SelectList(_context.Nacionalidade, "Id", "Descricao", pessoa.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(_context.Sexo, "Id", "Descricao", pessoa.SexoId);
            ViewData["TipoPessoaId"] = new SelectList(_context.TipoPessoa, "Id", "Descricao", pessoa.TipoPessoaId);
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            ViewData["NacionalidadeId"] = new SelectList(_context.Nacionalidade, "Id", "Descricao", pessoa.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(_context.Sexo, "Id", "Descricao", pessoa.SexoId);
            ViewData["TipoPessoaId"] = new SelectList(_context.TipoPessoa, "Id", "Descricao", pessoa.TipoPessoaId);
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomeFantasia,RazaoSocial,CpfCnpj,Rg,DataNascimento,NacionalidadeId,SexoId,TipoPessoaId,Ativo,Id,DataCriacao")] Entities.Entities.Pessoa.Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
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
            ViewData["NacionalidadeId"] = new SelectList(_context.Nacionalidade, "Id", "Descricao", pessoa.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(_context.Sexo, "Id", "Descricao", pessoa.SexoId);
            ViewData["TipoPessoaId"] = new SelectList(_context.TipoPessoa, "Id", "Descricao", pessoa.TipoPessoaId);
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .Include(p => p.Nacionalidade)
                .Include(p => p.Sexo)
                .Include(p => p.TipoPessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
