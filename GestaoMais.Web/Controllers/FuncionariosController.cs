using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoMais.Entities.Entities;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Application.Interfaces;
using GestaoMais.Application.Interfaces.Pessoa;

namespace GestaoMais.Web.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IFuncionario _context;

        public FuncionariosController(IFuncionario context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.GetById((int)id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList("Id", "RazaoSocial");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,PessoaId,Id")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(funcionario);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", funcionario.PessoaId);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.GetById((int)id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", funcionario.PessoaId);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricula,PessoaId,Id")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(funcionario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FuncionarioExists(funcionario.Id))
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
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", funcionario.PessoaId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.GetById((int)id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.GetById(id);
            await _context.Delete(funcionario);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FuncionarioExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
