using GestaoMais.Application.Interfaces.Sistema;
using GestaoMais.Entities.Entities.Sistema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GestaoMais.Web.Controllers.Sistema
{
    public class SexoesController : Controller
    {
        private readonly ISexo _context;

        public SexoesController(ISexo context)
        {
            _context = context;
        }

        // GET: Sexoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Sexoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexo = await _context.GetById((int)id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // GET: Sexoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sexoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id")] Sexo sexo)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(sexo);
                return RedirectToAction(nameof(Index));
            }
            return View(sexo);
        }

        // GET: Sexoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexo = await _context.GetById((int)id);
            if (sexo == null)
            {
                return NotFound();
            }
            return View(sexo);
        }

        // POST: Sexoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Id")] Sexo sexo)
        {
            if (id != sexo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(sexo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await SexoExists(sexo.Id))
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
            return View(sexo);
        }

        // GET: Sexoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexo = await _context.GetById((int)id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // POST: Sexoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sexo = await _context.GetById(id);
            await _context.Delete(sexo);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SexoExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
