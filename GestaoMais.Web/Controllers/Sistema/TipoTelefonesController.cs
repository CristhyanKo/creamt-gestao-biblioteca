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
    public class TipoTelefonesController : Controller
    {
        private readonly ITipoTelefone _context;

        public TipoTelefonesController(ITipoTelefone context)
        {
            _context = context;
        }

        // GET: TipoTelefones
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: TipoTelefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTelefone = await _context.GetById((int)id);
            if (tipoTelefone == null)
            {
                return NotFound();
            }

            return View(tipoTelefone);
        }

        // GET: TipoTelefones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTelefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id")] TipoTelefone tipoTelefone)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(tipoTelefone);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTelefone);
        }

        // GET: TipoTelefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTelefone = await _context.GetById((int)id);
            if (tipoTelefone == null)
            {
                return NotFound();
            }
            return View(tipoTelefone);
        }

        // POST: TipoTelefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Id")] TipoTelefone tipoTelefone)
        {
            if (id != tipoTelefone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(tipoTelefone);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TipoTelefoneExists(tipoTelefone.Id))
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
            return View(tipoTelefone);
        }

        // GET: TipoTelefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTelefone = await _context.GetById((int)id);
            if (tipoTelefone == null)
            {
                return NotFound();
            }

            return View(tipoTelefone);
        }

        // POST: TipoTelefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTelefone = await _context.GetById(id);
            await _context.Delete(tipoTelefone);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TipoTelefoneExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
