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
    public class PacotesController : Controller
    {
        private readonly AppDbContext _context;

        public PacotesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pacotes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Pacote.Include(p => p.FkClienteIdClienteNavigation).Include(p => p.FkHospedagemIdHospedagemNavigation).Include(p => p.FkPassagemIdPassagemNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Pacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacote
                .Include(p => p.FkClienteIdClienteNavigation)
                .Include(p => p.FkHospedagemIdHospedagemNavigation)
                .Include(p => p.FkPassagemIdPassagemNavigation)
                .FirstOrDefaultAsync(m => m.IdPacote == id);
            if (pacote == null)
            {
                return NotFound();
            }

            return View(pacote);
        }

        // GET: Pacotes/Create
        public IActionResult Create()
        {
            ViewData["FkClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente");
            ViewData["FkHospedagemIdHospedagem"] = new SelectList(_context.Hospedagem, "IdHospedagem", "IdHospedagem");
            ViewData["FkPassagemIdPassagem"] = new SelectList(_context.Passagem, "IdPassagem", "IdPassagem");
            return View();
        }

        // POST: Pacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPacote,Tipo,FkClienteIdCliente,FkPassagemIdPassagem,FkHospedagemIdHospedagem")] Pacote pacote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente", pacote.FkClienteIdCliente);
            ViewData["FkHospedagemIdHospedagem"] = new SelectList(_context.Hospedagem, "IdHospedagem", "IdHospedagem", pacote.FkHospedagemIdHospedagem);
            ViewData["FkPassagemIdPassagem"] = new SelectList(_context.Passagem, "IdPassagem", "IdPassagem", pacote.FkPassagemIdPassagem);
            return View(pacote);
        }

        // GET: Pacotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacote.FindAsync(id);
            if (pacote == null)
            {
                return NotFound();
            }
            ViewData["FkClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente", pacote.FkClienteIdCliente);
            ViewData["FkHospedagemIdHospedagem"] = new SelectList(_context.Hospedagem, "IdHospedagem", "IdHospedagem", pacote.FkHospedagemIdHospedagem);
            ViewData["FkPassagemIdPassagem"] = new SelectList(_context.Passagem, "IdPassagem", "IdPassagem", pacote.FkPassagemIdPassagem);
            return View(pacote);
        }

        // POST: Pacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPacote,Tipo,FkClienteIdCliente,FkPassagemIdPassagem,FkHospedagemIdHospedagem")] Pacote pacote)
        {
            if (id != pacote.IdPacote)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteExists(pacote.IdPacote))
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
            ViewData["FkClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente", pacote.FkClienteIdCliente);
            ViewData["FkHospedagemIdHospedagem"] = new SelectList(_context.Hospedagem, "IdHospedagem", "IdHospedagem", pacote.FkHospedagemIdHospedagem);
            ViewData["FkPassagemIdPassagem"] = new SelectList(_context.Passagem, "IdPassagem", "IdPassagem", pacote.FkPassagemIdPassagem);
            return View(pacote);
        }

        // GET: Pacotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacote
                .Include(p => p.FkClienteIdClienteNavigation)
                .Include(p => p.FkHospedagemIdHospedagemNavigation)
                .Include(p => p.FkPassagemIdPassagemNavigation)
                .FirstOrDefaultAsync(m => m.IdPacote == id);
            if (pacote == null)
            {
                return NotFound();
            }

            return View(pacote);
        }

        // POST: Pacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacote = await _context.Pacote.FindAsync(id);
            _context.Pacote.Remove(pacote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacoteExists(int id)
        {
            return _context.Pacote.Any(e => e.IdPacote == id);
        }
    }
}
