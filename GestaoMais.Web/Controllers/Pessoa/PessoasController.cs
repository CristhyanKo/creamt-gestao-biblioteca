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
    public class PessoasController : Controller
    {
        private readonly IPessoa _context;

        public PessoasController(IPessoa context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.GetById((int)id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            ViewData["NacionalidadeId"] = new SelectList("Id", "Descricao");
            ViewData["SexoId"] = new SelectList("Id", "Descricao");
            ViewData["TipoPessoaId"] = new SelectList("Id", "Descricao");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeFantasia,RazaoSocial,CpfCnpj,Rg,DataNascimento,NacionalidadeId,SexoId,TipoPessoaId,Ativo,Id")] Entities.Entities.Pessoa.Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(pessoa);
                return RedirectToAction(nameof(Index));
            }
            ViewData["NacionalidadeId"] = new SelectList(null, "Id", "Descricao", pessoa.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(null, "Id", "Descricao", pessoa.SexoId);
            ViewData["TipoPessoaId"] = new SelectList(null, "Id", "Descricao", pessoa.TipoPessoaId);
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.GetById((int)id);
            if (pessoa == null)
            {
                return NotFound();
            }
            ViewData["NacionalidadeId"] = new SelectList(null, "Id", "Descricao", pessoa.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(null, "Id", "Descricao", pessoa.SexoId);
            ViewData["TipoPessoaId"] = new SelectList(null, "Id", "Descricao", pessoa.TipoPessoaId);
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomeFantasia,RazaoSocial,CpfCnpj,Rg,DataNascimento,NacionalidadeId,SexoId,TipoPessoaId,Ativo,Id")] Entities.Entities.Pessoa.Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(pessoa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PessoaExists(pessoa.Id))
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
            ViewData["NacionalidadeId"] = new SelectList(null, "Id", "Descricao", pessoa.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(null, "Id", "Descricao", pessoa.SexoId);
            ViewData["TipoPessoaId"] = new SelectList(null, "Id", "Descricao", pessoa.TipoPessoaId);
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.GetById((int)id);
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
            var pessoa = await _context.GetById(id);
            await _context.Delete(pessoa);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PessoaExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
