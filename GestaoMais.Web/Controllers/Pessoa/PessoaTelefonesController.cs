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
using GestaoMais.Application.Interfaces.Sistema;

namespace GestaoMais.Web.Controllers.Pessoa
{
    public class PessoaTelefonesController : Controller
    {
        private readonly IPessoaTelefone _context;
        private readonly IPessoa _contextPessoa;
        private readonly ITipoTelefone _contextTipoTelefone;

        public PessoaTelefonesController(IPessoaTelefone context, IPessoa contextPessoa, ITipoTelefone contextTipoTelefone)
        {
            _context = context;
            _contextPessoa = contextPessoa;
            _contextTipoTelefone = contextTipoTelefone;
        }

        // GET: PessoaTelefones/5
        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.List((int)id));
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

        // GET: PessoaTelefones/Create/5
        public async Task<IActionResult> Create(int id)
        {
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", id);
            ViewData["TipoTelefoneId"] = new SelectList(await _contextTipoTelefone.List(), "Id", "Descricao");
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
                pessoaTelefone.Id = 0;
                await _context.AddTelefone(pessoaTelefone);
                return RedirectToAction("Edit", "Pessoas", new { id = pessoaTelefone.PessoaId });
            }

            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", pessoaTelefone.PessoaId);
            ViewData["TipoTelefoneId"] = new SelectList(await _contextTipoTelefone.List(), "Id", "Descricao", pessoaTelefone.TipoTelefoneId);
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
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", pessoaTelefone.PessoaId);
            ViewData["TipoTelefoneId"] = new SelectList(await _contextTipoTelefone.List(), "Id", "Descricao", pessoaTelefone.TipoTelefoneId);
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
                    await _context.UpdateTelefone(pessoaTelefone);
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
                return RedirectToAction("Edit", "Pessoas", new { id = pessoaTelefone.PessoaId });
            }
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", pessoaTelefone.PessoaId);
            ViewData["TipoTelefoneId"] = new SelectList(await _contextTipoTelefone.List(), "Id", "Descricao", pessoaTelefone.TipoTelefoneId);
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
            return RedirectToAction("Edit", "Pessoas", new { id = pessoaTelefone.PessoaId });
        }

        private async Task<bool> PessoaTelefoneExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
