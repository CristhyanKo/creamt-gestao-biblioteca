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
    public class AlunoesController : Controller
    {
        private readonly IAluno _context;
        private readonly IPessoa _contextPessoa;

        public AlunoesController(IAluno context, IPessoa contextPessoa)
        {
            _context = context;
            _contextPessoa = contextPessoa;
        }

        // GET: Alunoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Alunoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.GetById((int)id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunoes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome");
            return View();
        }

        // POST: Alunoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,PessoaId,Id")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(aluno);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", aluno.PessoaId);
            return View(aluno);
        }

        // GET: Alunoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.GetById((int) id);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", aluno.PessoaId);
            return View(aluno);
        }

        // POST: Alunoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricula,PessoaId,Id")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(aluno);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AlunoExists(aluno.Id))
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
            ViewData["PessoaId"] = new SelectList(await _contextPessoa.ListActive(), "Id", "Nome", aluno.PessoaId);
            return View(aluno);
        }

        // GET: Alunoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.GetById((int) id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.GetById(id);
            await _context.Delete(aluno);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AlunoExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
