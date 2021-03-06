using GestaoMais.Application.Interfaces.Pessoa;
using GestaoMais.Application.Interfaces.Sistema;
using GestaoMais.Entities.Entities.Pessoa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoMais.Web.Controllers.Pessoa
{
    public class ViewModel
    {
        public Entities.Entities.Pessoa.Pessoa Pessoa { get; set; }
        public PessoaTelefone PessoaTelefone { get; set; }
        public PessoaEmail PessoaEmails { get; set; }
        public IEnumerable<Entities.Entities.Pessoa.Pessoa> ListPessoa { get; set; }
        public IEnumerable<PessoaTelefone> ListPessoaTelefone { get; set; }
        public IEnumerable<PessoaEmail> ListPessoaEmail { get; set; }
    }

    public class PessoasController : Controller
    {
        private readonly IPessoa _context;
        private readonly INacionalidade _contextNacionalidade;
        private readonly ISexo _contextSexo;
        private readonly ITipoPessoa _contextTipoPessoa;
        private readonly IPessoaTelefone _contextPessoaTelefone;
        private readonly IPessoaEmail _contextPessoaEmail;

        public PessoasController(IPessoa context, INacionalidade contextNacionalidade, ISexo contextSexo, ITipoPessoa contextTipoPessoa, IPessoaTelefone contextPessoaTelefone, IPessoaEmail contextPessoaEmail)
        {
            _context = context;
            _contextNacionalidade = contextNacionalidade;
            _contextSexo = contextSexo;
            _contextTipoPessoa = contextTipoPessoa;
            _contextPessoaTelefone = contextPessoaTelefone;
            _contextPessoaEmail = contextPessoaEmail;
        }

      

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.List());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.GetById((int)id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public async Task<IActionResult> Create()
        {
            ViewData["NacionalidadeId"] = new SelectList(await _contextNacionalidade.List(), "Id", "Descricao");
            ViewData["SexoId"] = new SelectList(await _contextSexo.List(),"Id", "Descricao");
            ViewData["TipoPessoaId"] = new SelectList(await _contextTipoPessoa.List(),"Id", "Descricao");

            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,CpfCnpj,Rg,DataNascimento,NacionalidadeId,SexoId,TipoPessoaId,Logradouro,Bairro,Municipio,Cep,Numero,Ativo,Id")] Entities.Entities.Pessoa.Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(pessoa);
                return RedirectToAction(nameof(Index));
            }
            ViewData["NacionalidadeId"] = new SelectList(await _contextNacionalidade.List(), "Id", "Descricao", pessoa.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(await _contextSexo.List(), "Id", "Descricao", pessoa.SexoId);
            ViewData["TipoPessoaId"] = new SelectList(await _contextTipoPessoa.List(), "Id", "Descricao", pessoa.TipoPessoaId);
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.GetById((int)id);
            if (pessoa == null)
            {
                return NotFound();
            }
            ViewData["NacionalidadeId"] = new SelectList(await _contextNacionalidade.List(), "Id", "Descricao", pessoa.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(await _contextSexo.List(), "Id", "Descricao", pessoa.SexoId);
            ViewData["TipoPessoaId"] = new SelectList(await _contextTipoPessoa.List(), "Id", "Descricao", pessoa.TipoPessoaId);

            ViewModel models = new ViewModel();
            models.Pessoa = pessoa;
            models.ListPessoa = await _context.List();
            models.ListPessoaTelefone = await _contextPessoaTelefone.List(pessoa.Id);
            models.ListPessoaEmail = await _contextPessoaEmail.List(pessoa.Id);

            return View(models);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,CpfCnpj,Rg,DataNascimento,NacionalidadeId,SexoId,TipoPessoaId,Logradouro,Bairro,Municipio,Cep,Numero,Ativo,Id")] Entities.Entities.Pessoa.Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(pessoa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PessoaExists(pessoa.Id))
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
            ViewData["NacionalidadeId"] = new SelectList(await _contextNacionalidade.List(), "Id", "Descricao", pessoa.NacionalidadeId);
            ViewData["SexoId"] = new SelectList(await _contextSexo.List(), "Id", "Descricao", pessoa.SexoId);
            ViewData["TipoPessoaId"] = new SelectList(await _contextTipoPessoa.List(), "Id", "Descricao", pessoa.TipoPessoaId);
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.GetById((int)id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.GetById(id);
            await _context.Delete(pessoa);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PessoaExists(int id)
        {
            var obj = await _context.GetById(id);
            return obj != null;
        }
    }
}
