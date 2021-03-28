﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoMais.Entities.Entities.Movimentacao;
using GestaoMais.Infrastructure.Configuration;
using GestaoMais.Application.Interfaces.Movimentacao;

namespace GestaoMais.Web.Controllers.Movimentacao
{
    public class MovimentacaosController : Controller
    {
        private readonly IMovimentacao _context;

        public MovimentacaosController(IMovimentacao context)
        {
            _context = context;
        }

        // GET: Movimentacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Movimentacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.GetById((int)id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: Movimentacaos/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList("Id", "Id");
            ViewData["LivroId"] = new SelectList("Id", "Edicao");
            ViewData["MovimentacaoSituacaoId"] = new SelectList("Id", "Nome");
            ViewData["PessoaId"] = new SelectList("Id", "Nome");
            return View();
        }

        // POST: Movimentacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LivroId,PessoaId,FuncionarioId,EmprestimoLocal,DataEmprestimo,DataLimiteDevolucao,DataDevolucao,MovimentacaoSituacaoId,Id")] Entities.Entities.Movimentacao.Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(movimentacao);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(null, "Id", "Id", movimentacao.FuncionarioId);
            ViewData["LivroId"] = new SelectList(null, "Id", "Edicao", movimentacao.LivroId);
            ViewData["MovimentacaoSituacaoId"] = new SelectList(null, "Id", "Nome", movimentacao.MovimentacaoSituacaoId);
            ViewData["PessoaId"] = new SelectList(null, "Id", "Nome", movimentacao.PessoaId);
            return View(movimentacao);
        }

        // GET: Movimentacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.GetById((int)id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(null, "Id", "Id", movimentacao.FuncionarioId);
            ViewData["LivroId"] = new SelectList(null, "Id", "Edicao", movimentacao.LivroId);
            ViewData["MovimentacaoSituacaoId"] = new SelectList(null, "Id", "Nome", movimentacao.MovimentacaoSituacaoId);
            ViewData["PessoaId"] = new SelectList(null, "Id", "Nome", movimentacao.PessoaId);
            return View(movimentacao);
        }

        // POST: Movimentacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LivroId,PessoaId,FuncionarioId,EmprestimoLocal,DataEmprestimo,DataLimiteDevolucao,DataDevolucao,MovimentacaoSituacaoId,Id")] Entities.Entities.Movimentacao.Movimentacao movimentacao)
        {
            if (id != movimentacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(movimentacao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MovimentacaoExists(movimentacao.Id))
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
            ViewData["FuncionarioId"] = new SelectList(null, "Id", "Id", movimentacao.FuncionarioId);
            ViewData["LivroId"] = new SelectList(null, "Id", "Edicao", movimentacao.LivroId);
            ViewData["MovimentacaoSituacaoId"] = new SelectList(null, "Id", "Nome", movimentacao.MovimentacaoSituacaoId);
            ViewData["PessoaId"] = new SelectList(null, "Id", "Nome", movimentacao.PessoaId);
            return View(movimentacao);
        }

        // GET: Movimentacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.GetById((int)id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: Movimentacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacao = await _context.GetById(id);
            await _context.Delete(movimentacao);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MovimentacaoExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
