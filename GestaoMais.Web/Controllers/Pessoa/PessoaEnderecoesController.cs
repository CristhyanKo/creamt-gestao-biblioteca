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
    public class PessoaEnderecoesController : Controller
    {
        private readonly ContextBase _context;

        public PessoaEnderecoesController(ContextBase context)
        {
            _context = context;
        }

        // GET: PessoaEnderecoes
        public async Task<IActionResult> Index()
        {
            var contextBase = _context.PessoaEndereco.Include(p => p.Endereco).Include(p => p.Pessoa);
            return View(await contextBase.ToListAsync());
        }

        // GET: PessoaEnderecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEndereco = await _context.PessoaEndereco
                .Include(p => p.Endereco)
                .Include(p => p.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaEndereco == null)
            {
                return NotFound();
            }

            return View(pessoaEndereco);
        }

        // GET: PessoaEnderecoes/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro");
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial");
            return View();
        }

        // POST: PessoaEnderecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,EnderecoId,Principal,Id,DataCriacao")] PessoaEndereco pessoaEndereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaEndereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro", pessoaEndereco.EnderecoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", pessoaEndereco.PessoaId);
            return View(pessoaEndereco);
        }

        // GET: PessoaEnderecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEndereco = await _context.PessoaEndereco.FindAsync(id);
            if (pessoaEndereco == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro", pessoaEndereco.EnderecoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", pessoaEndereco.PessoaId);
            return View(pessoaEndereco);
        }

        // POST: PessoaEnderecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,EnderecoId,Principal,Id,DataCriacao")] PessoaEndereco pessoaEndereco)
        {
            if (id != pessoaEndereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaEndereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaEnderecoExists(pessoaEndereco.Id))
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
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro", pessoaEndereco.EnderecoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", pessoaEndereco.PessoaId);
            return View(pessoaEndereco);
        }

        // GET: PessoaEnderecoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEndereco = await _context.PessoaEndereco
                .Include(p => p.Endereco)
                .Include(p => p.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaEndereco == null)
            {
                return NotFound();
            }

            return View(pessoaEndereco);
        }

        // POST: PessoaEnderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaEndereco = await _context.PessoaEndereco.FindAsync(id);
            _context.PessoaEndereco.Remove(pessoaEndereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaEnderecoExists(int id)
        {
            return _context.PessoaEndereco.Any(e => e.Id == id);
        }
    }
}
