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

namespace GestaoMais.Web.Controllers
{
    public class EditorasController : Controller
    {
        private readonly IEditora _context;

        public EditorasController(IEditora context)
        {
            _context = context;
        }

        // GET: Editoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Editoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editora = await _context.GetById((int)id);
            if (editora == null)
            {
                return NotFound();
            }

            return View(editora);
        }

        // GET: Editoras/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList( "Id", "RazaoSocial");
            return View();
        }

        // POST: Editoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,Id")] Editora editora)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(editora);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", editora.PessoaId);
            return View(editora);
        }

        // GET: Editoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editora = await _context.GetById((int)id);
            if (editora == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", editora.PessoaId);
            return View(editora);
        }

        // POST: Editoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,Id")] Editora editora)
        {
            if (id != editora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(editora);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await EditoraExists(editora.Id))
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
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", editora.PessoaId);
            return View(editora);
        }

        // GET: Editoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editora = await _context.GetById((int)id);
            if (editora == null)
            {
                return NotFound();
            }

            return View(editora);
        }

        // POST: Editoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editora = await _context.GetById(id);
            await _context.Delete(editora);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EditoraExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
