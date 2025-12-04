using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaJogo.Data;
using SistemaJogo.Models;

namespace SistemaJogo.Controllers
{
    public class JogoController : Controller
    {
        private readonly AppDbContext _context;

        public JogoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Jogo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabelaJogos.ToListAsync());
        }

        // GET: Jogo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaJogo = await _context.TabelaJogos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelaJogo == null)
            {
                return NotFound();
            }

            return View(tabelaJogo);
        }

        // GET: Jogo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Nivel,Classe")] TabelaJogo tabelaJogo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabelaJogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabelaJogo);
        }

        // GET: Jogo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaJogo = await _context.TabelaJogos.FindAsync(id);
            if (tabelaJogo == null)
            {
                return NotFound();
            }
            return View(tabelaJogo);
        }

        // POST: Jogo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Nivel,Classe")] TabelaJogo tabelaJogo)
        {
            if (id != tabelaJogo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabelaJogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabelaJogoExists(tabelaJogo.Id))
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
            return View(tabelaJogo);
        }

        // GET: Jogo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaJogo = await _context.TabelaJogos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelaJogo == null)
            {
                return NotFound();
            }

            return View(tabelaJogo);
        }

        // POST: Jogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabelaJogo = await _context.TabelaJogos.FindAsync(id);
            if (tabelaJogo != null)
            {
                _context.TabelaJogos.Remove(tabelaJogo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabelaJogoExists(int id)
        {
            return _context.TabelaJogos.Any(e => e.Id == id);
        }
    }
}
