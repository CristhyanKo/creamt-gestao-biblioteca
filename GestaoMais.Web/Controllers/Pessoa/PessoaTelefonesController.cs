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
    public class PessoaTelefonesController : Controller
    {
        private readonly ContextBase _context;

        public PessoaTelefonesController(ContextBase context)
        {
            _context = context;
        }

        // GET: PessoaTelefones
        public async Task<IActionResult> Index()
        {
            var contextBase = _context.PessoaTelefone.Include(p => p.Pessoa).Include(p => p.TipoTelefone);
            return View(await contextBase.ToListAsync());
        }

        // GET: PessoaTelefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaTelefone = await _context.PessoaTelefone
                .Include(p => p.Pessoa)
                .Include(p => p.TipoTelefone)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaTelefone == null)
            {
                return NotFound();
            }

            return View(pessoaTelefone);
        }

        // GET: PessoaTelefones/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial");
            ViewData["TipoTelefoneId"] = new SelectList(_context.TipoTelefone, "Id", "Descricao");
            return View();
        }

        // POST: PessoaTelefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,TipoTelefoneId,Ddd,Numero,Principal,Id,DataCriacao")] PessoaTelefone pessoaTelefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaTelefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", pessoaTelefone.PessoaId);
            ViewData["TipoTelefoneId"] = new SelectList(_context.TipoTelefone, "Id", "Descricao", pessoaTelefone.TipoTelefoneId);
            return View(pessoaTelefone);
        }

        // GET: PessoaTelefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaTelefone = await _context.PessoaTelefone.FindAsync(id);
            if (pessoaTelefone == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", pessoaTelefone.PessoaId);
            ViewData["TipoTelefoneId"] = new SelectList(_context.TipoTelefone, "Id", "Descricao", pessoaTelefone.TipoTelefoneId);
            return View(pessoaTelefone);
        }

        // POST: PessoaTelefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,TipoTelefoneId,Ddd,Numero,Principal,Id,DataCriacao")] PessoaTelefone pessoaTelefone)
        {
            if (id != pessoaTelefone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaTelefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaTelefoneExists(pessoaTelefone.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", pessoaTelefone.PessoaId);
            ViewData["TipoTelefoneId"] = new SelectList(_context.TipoTelefone, "Id", "Descricao", pessoaTelefone.TipoTelefoneId);
            return View(pessoaTelefone);
        }

        // GET: PessoaTelefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaTelefone = await _context.PessoaTelefone
                .Include(p => p.Pessoa)
                .Include(p => p.TipoTelefone)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaTelefone == null)
            {
                return NotFound();
            }

            return View(pessoaTelefone);
        }

        // POST: PessoaTelefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaTelefone = await _context.PessoaTelefone.FindAsync(id);
            _context.PessoaTelefone.Remove(pessoaTelefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaTelefoneExists(int id)
        {
            return _context.PessoaTelefone.Any(e => e.Id == id);
        }
    }
}
