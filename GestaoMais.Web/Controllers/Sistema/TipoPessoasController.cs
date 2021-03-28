using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoMais.Entities.Entities.Sistema;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Application.Interfaces.Sistema;

namespace GestaoMais.Web.Controllers.Sistema
{
    public class TipoPessoasController : Controller
    {
        private readonly ITipoPessoa _context;

        public TipoPessoasController(ITipoPessoa context)
        {
            _context = context;
        }

        // GET: TipoPessoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: TipoPessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPessoa = await _context.GetById((int)id);
            if (tipoPessoa == null)
            {
                return NotFound();
            }

            return View(tipoPessoa);
        }

        // GET: TipoPessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id")] TipoPessoa tipoPessoa)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(tipoPessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPessoa);
        }

        // GET: TipoPessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPessoa = await _context.GetById((int)id);
            if (tipoPessoa == null)
            {
                return NotFound();
            }
            return View(tipoPessoa);
        }

        // POST: TipoPessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Id")] TipoPessoa tipoPessoa)
        {
            if (id != tipoPessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(tipoPessoa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TipoPessoaExists(tipoPessoa.Id))
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
            return View(tipoPessoa);
        }

        // GET: TipoPessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPessoa = await _context.GetById((int)id);
            if (tipoPessoa == null)
            {
                return NotFound();
            }

            return View(tipoPessoa);
        }

        // POST: TipoPessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPessoa = await _context.GetById(id);
            await _context.Delete(tipoPessoa);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TipoPessoaExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
