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
    public class PessoaEnderecoesController : Controller
    {
        private readonly IPessoaEndereco _context;

        public PessoaEnderecoesController(IPessoaEndereco context)
        {
            _context = context;
        }

        // GET: PessoaEnderecoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: PessoaEnderecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEndereco = await _context.GetById((int)id);
            if (pessoaEndereco == null)
            {
                return NotFound();
            }

            return View(pessoaEndereco);
        }

        // GET: PessoaEnderecoes/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList("Id", "Bairro");
            ViewData["PessoaId"] = new SelectList("Id", "Nome");
            return View();
        }

        // POST: PessoaEnderecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,EnderecoId,Principal,Id")] PessoaEndereco pessoaEndereco)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(pessoaEndereco);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(null, "Id", "Bairro", pessoaEndereco.EnderecoId);
            ViewData["PessoaId"] = new SelectList(null, "Id", "Nome", pessoaEndereco.PessoaId);
            return View(pessoaEndereco);
        }

        // GET: PessoaEnderecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEndereco = await _context.GetById((int)id);
            if (pessoaEndereco == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(null, "Id", "Bairro", pessoaEndereco.EnderecoId);
            ViewData["PessoaId"] = new SelectList(null, "Id", "Nome", pessoaEndereco.PessoaId);
            return View(pessoaEndereco);
        }

        // POST: PessoaEnderecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,EnderecoId,Principal,Id")] PessoaEndereco pessoaEndereco)
        {
            if (id != pessoaEndereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(pessoaEndereco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PessoaEnderecoExists(pessoaEndereco.Id))
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
            ViewData["EnderecoId"] = new SelectList(null, "Id", "Bairro", pessoaEndereco.EnderecoId);
            ViewData["PessoaId"] = new SelectList(null, "Id", "Nome", pessoaEndereco.PessoaId);
            return View(pessoaEndereco);
        }

        // GET: PessoaEnderecoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaEndereco = await _context.GetById((int)id);
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
            var pessoaEndereco = await _context.GetById(id);
            await _context.Delete(pessoaEndereco);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PessoaEnderecoExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
