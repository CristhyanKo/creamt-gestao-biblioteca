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
    public class PessoaTelefonesController : Controller
    {
        private readonly IPessoaTelefone _context;

        public PessoaTelefonesController(IPessoaTelefone context)
        {
            _context = context;
        }

        // GET: PessoaTelefones
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: PessoaTelefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaTelefone = await _context.GetById((int)id);
            if (pessoaTelefone == null)
            {
                return NotFound();
            }

            return View(pessoaTelefone);
        }

        // GET: PessoaTelefones/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList( "Id", "RazaoSocial");
            ViewData["TipoTelefoneId"] = new SelectList( "Id", "Descricao");
            return View();
        }

        // POST: PessoaTelefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,TipoTelefoneId,Ddd,Numero,Principal,Id")] PessoaTelefone pessoaTelefone)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(pessoaTelefone);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", pessoaTelefone.PessoaId);
            ViewData["TipoTelefoneId"] = new SelectList(null, "Id", "Descricao", pessoaTelefone.TipoTelefoneId);
            return View(pessoaTelefone);
        }

        // GET: PessoaTelefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaTelefone = await _context.GetById((int)id);
            if (pessoaTelefone == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", pessoaTelefone.PessoaId);
            ViewData["TipoTelefoneId"] = new SelectList(null, "Id", "Descricao", pessoaTelefone.TipoTelefoneId);
            return View(pessoaTelefone);
        }

        // POST: PessoaTelefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,TipoTelefoneId,Ddd,Numero,Principal,Id")] PessoaTelefone pessoaTelefone)
        {
            if (id != pessoaTelefone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(pessoaTelefone);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PessoaTelefoneExists(pessoaTelefone.Id))
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
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", pessoaTelefone.PessoaId);
            ViewData["TipoTelefoneId"] = new SelectList(null, "Id", "Descricao", pessoaTelefone.TipoTelefoneId);
            return View(pessoaTelefone);
        }

        // GET: PessoaTelefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaTelefone = await _context.GetById((int)id);
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
            var pessoaTelefone = await _context.GetById(id);
            await _context.Delete(pessoaTelefone);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PessoaTelefoneExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
