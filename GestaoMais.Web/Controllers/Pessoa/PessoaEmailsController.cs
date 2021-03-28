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

        public PessoaEmailsController(IPessoaEmail context)
        {
            _context = context;
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
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList("Id", "RazaoSocial");
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
                await _context.Add(pessoaEmail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", pessoaEmail.PessoaId);
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
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", pessoaEmail.PessoaId);
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
                    await _context.Update(pessoaEmail);
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", pessoaEmail.PessoaId);
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
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PessoaEmailExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
