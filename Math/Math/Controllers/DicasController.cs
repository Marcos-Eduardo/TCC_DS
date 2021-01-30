using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Math.Data;
using Math.Models;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace Math.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class DicasController : Controller
    {
        private readonly MathContext _context;

        public DicasController(MathContext context)
        {
            _context = context;
        }

        // GET: Dicas
        public async Task<IActionResult> Index(string filtro, string pesquisa, int? pagina)
        {
            if (pesquisa != null)
            {
                pagina = 1;
            }
            else
            {
                pesquisa = filtro;
            }

            ViewData["Filtro"] = pesquisa;

            var dicas = from d in _context.Dicas.Include(d => d.Conteudo) select d;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                dicas = dicas.Where(d => d.Titulo.Contains(pesquisa)).AsNoTracking();
            }

            pagina = pagina ?? 1;
            int itensPorPagina = 12;

            return View(await dicas.ToPagedListAsync(pagina, itensPorPagina));
        }

        // GET: Dicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dica = await _context.Dicas
                .Include(d => d.Conteudo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dica == null)
            {
                return NotFound();
            }

            return View(dica);
        }

        // GET: Dicas/Create
        public IActionResult Create()
        {
            ViewData["ConteudoId"] = new SelectList(_context.Conteudos, "Id", "Titulo");
            return View();
        }

        // POST: Dicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,LinkVideo,ConteudoId")] Dica dica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConteudoId"] = new SelectList(_context.Conteudos, "Id", "Titulo", dica.ConteudoId);
            return View(dica);
        }

        // GET: Dicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dica = await _context.Dicas.FindAsync(id);
            if (dica == null)
            {
                return NotFound();
            }
            ViewData["ConteudoId"] = new SelectList(_context.Conteudos, "Id", "Titulo", dica.ConteudoId);
            return View(dica);
        }

        // POST: Dicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,LinkVideo,ConteudoId")] Dica dica)
        {
            if (id != dica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DicaExists(dica.Id))
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
            ViewData["ConteudoId"] = new SelectList(_context.Conteudos, "Id", "Titulo", dica.ConteudoId);
            return View(dica);
        }

        // GET: Dicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dica = await _context.Dicas
                .Include(d => d.Conteudo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dica == null)
            {
                return NotFound();
            }

            return View(dica);
        }

        // POST: Dicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dica = await _context.Dicas.FindAsync(id);
            _context.Dicas.Remove(dica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DicaExists(int id)
        {
            return _context.Dicas.Any(e => e.Id == id);
        }
    }
}
