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
    public class NacionalidadesController : Controller
    {
        private readonly INacionalidade _context;

        public NacionalidadesController(INacionalidade context)
        {
            _context = context;
        }

        // GET: Nacionalidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Nacionalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.GetById((int)id);
            if (nacionalidade == null)
            {
                return NotFound();
            }

            return View(nacionalidade);
        }

        // GET: Nacionalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nacionalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id")] Nacionalidade nacionalidade)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(nacionalidade);
                return RedirectToAction(nameof(Index));
            }
            return View(nacionalidade);
        }

        // GET: Nacionalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.GetById((int)id);
            if (nacionalidade == null)
            {
                return NotFound();
            }
            return View(nacionalidade);
        }

        // POST: Nacionalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Id")] Nacionalidade nacionalidade)
        {
            if (id != nacionalidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(nacionalidade);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await NacionalidadeExists(nacionalidade.Id))
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
            return View(nacionalidade);
        }

        // GET: Nacionalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidade = await _context.GetById((int)id);
            if (nacionalidade == null)
            {
                return NotFound();
            }

            return View(nacionalidade);
        }

        // POST: Nacionalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nacionalidade = await _context.GetById(id);
            await _context.Delete(nacionalidade);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> NacionalidadeExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
