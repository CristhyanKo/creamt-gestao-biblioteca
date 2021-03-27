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
    public class PessoaEmailsController : Controller
    {
        private readonly ContextBase _context;

        public PessoaEmailsController(ContextBase context)
        {
            _context = context;
        }

        // GET: PessoaEmails
        public async Task<IActionResult> Index()
        {
            var contextBase = _context.PessoaEmail.Include(p => p.Pessoa);
            return View(await contextBase.ToListAsync());
        }

        // GET: PessoaEmails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEmail = await _context.PessoaEmail
                .Include(p => p.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaEmail == null)
            {
                return NotFound();
            }

            return View(pessoaEmail);
        }

        // GET: PessoaEmails/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial");
            return View();
        }

        // POST: PessoaEmails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,Email,Principal,Id,DataCriacao")] PessoaEmail pessoaEmail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaEmail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", pessoaEmail.PessoaId);
            return View(pessoaEmail);
        }

        // GET: PessoaEmails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEmail = await _context.PessoaEmail.FindAsync(id);
            if (pessoaEmail == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", pessoaEmail.PessoaId);
            return View(pessoaEmail);
        }

        // POST: PessoaEmails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,Email,Principal,Id,DataCriacao")] PessoaEmail pessoaEmail)
        {
            if (id != pessoaEmail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaEmail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaEmailExists(pessoaEmail.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "RazaoSocial", pessoaEmail.PessoaId);
            return View(pessoaEmail);
        }

        // GET: PessoaEmails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEmail = await _context.PessoaEmail
                .Include(p => p.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaEmail == null)
            {
                return NotFound();
            }

            return View(pessoaEmail);
        }

        // POST: PessoaEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaEmail = await _context.PessoaEmail.FindAsync(id);
            _context.PessoaEmail.Remove(pessoaEmail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaEmailExists(int id)
        {
            return _context.PessoaEmail.Any(e => e.Id == id);
        }
    }
}
