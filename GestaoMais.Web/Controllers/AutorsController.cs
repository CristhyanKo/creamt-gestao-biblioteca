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
    public class AutorsController : Controller
    {
        private readonly IAutor _context;

        public AutorsController(IAutor context)
        {
            _context = context;
        }

        // GET: Autors
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.GetById((int)id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autors/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList("Id", "RazaoSocial");
            return View();
        }

        // POST: Autors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,Id")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(autor);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", autor.PessoaId);
            return View(autor);
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.GetById((int)id);
            if (autor == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", autor.PessoaId);
            return View(autor);
        }

        // POST: Autors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,Id")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(autor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AutorExists(autor.Id))
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
            ViewData["PessoaId"] = new SelectList(null, "Id", "RazaoSocial", autor.PessoaId);
            return View(autor);
        }

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.GetById((int)id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = await _context.GetById(id);
            await _context.Delete(autor);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AutorExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
