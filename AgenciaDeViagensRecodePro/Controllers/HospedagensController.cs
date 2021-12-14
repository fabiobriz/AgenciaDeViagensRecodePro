using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaDeViagensRecodePro.Models;

namespace AgenciaDeViagensRecodePro.Controllers
{
    public class HospedagensController : Controller
    {
        private readonly AppDbContext _context;

        public HospedagensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Hospedagens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hospedagem.ToListAsync());
        }

        // GET: Hospedagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagem
                .FirstOrDefaultAsync(m => m.IdHospedagem == id);
            if (hospedagem == null)
            {
                return NotFound();
            }

            return View(hospedagem);
        }

        // GET: Hospedagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospedagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHospedagem,Nome,Endereco,Telefone,Diarias,ValorDiaria")] Hospedagem hospedagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospedagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospedagem);
        }

        // GET: Hospedagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagem.FindAsync(id);
            if (hospedagem == null)
            {
                return NotFound();
            }
            return View(hospedagem);
        }

        // POST: Hospedagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHospedagem,Nome,Endereco,Telefone,Diarias,ValorDiaria")] Hospedagem hospedagem)
        {
            if (id != hospedagem.IdHospedagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospedagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospedagemExists(hospedagem.IdHospedagem))
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
            return View(hospedagem);
        }

        // GET: Hospedagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospedagem = await _context.Hospedagem
                .FirstOrDefaultAsync(m => m.IdHospedagem == id);
            if (hospedagem == null)
            {
                return NotFound();
            }

            return View(hospedagem);
        }

        // POST: Hospedagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospedagem = await _context.Hospedagem.FindAsync(id);
            _context.Hospedagem.Remove(hospedagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospedagemExists(int id)
        {
            return _context.Hospedagem.Any(e => e.IdHospedagem == id);
        }
    }
}
