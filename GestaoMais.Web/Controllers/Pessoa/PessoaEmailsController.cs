using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoMais.Entities.Entities.Pessoa;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Application.Interfaces.Pessoa;

namespace GestaoMais.Web.Controllers.Pessoa
{
    public class PessoaEmailsController : Controller
    {
        private readonly IPessoaEmail _context;
        private readonly IPessoa _contextPessoa;

        public PessoaEmailsController(IPessoaEmail context, IPessoa contextPessoa)
        {
            _context = context;
            _contextPessoa = contextPessoa;
        }

        // GET: PessoaEmails/5
        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.List((int)id));
        }

        // GET: PessoaEmails
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: PessoaEmails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEmail = await _context.GetById((int)id);
            if (pessoaEmail == null)
            {
                return NotFound();
            }

            return View(pessoaEmail);
        }

        // GET: PessoaEmails/Create
        public async Task<IActionResult> Create()
        {
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(),"Id", "Nome");
            return View();
        }

        // POST: PessoaEmails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,Email,Principal,Id")] PessoaEmail pessoaEmail)
        {
            if (ModelState.IsValid)
            {
                pessoaEmail.Id = 0;
                await _context.AddEmail(pessoaEmail);
                return RedirectToAction("Edit", "Pessoas", new { id = pessoaEmail.PessoaId });
            }
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", pessoaEmail.PessoaId);
            return View(pessoaEmail);
        }

        // GET: PessoaEmails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEmail = await _context.GetById((int)id);
            if (pessoaEmail == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", pessoaEmail.PessoaId);
            return View(pessoaEmail);
        }

        // POST: PessoaEmails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,Email,Principal,Id")] PessoaEmail pessoaEmail)
        {
            if (id != pessoaEmail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateEmail(pessoaEmail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PessoaEmailExists(pessoaEmail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", "Pessoas", new { id = pessoaEmail.PessoaId });
            }
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", pessoaEmail.PessoaId);
            return View(pessoaEmail);
        }

        // GET: PessoaEmails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEmail = await _context.GetById((int)id);
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
            var pessoaEmail = await _context.GetById(id);
            await _context.Delete(pessoaEmail);
            return RedirectToAction("Edit", "Pessoas", new { id = pessoaEmail.PessoaId });
        }

        private async Task<bool> PessoaEmailExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
