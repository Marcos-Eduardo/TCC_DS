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
    public class QuizesController : Controller
    {
        private readonly MathContext _context;

        public QuizesController(MathContext context)
        {
            _context = context;
        }

        // GET: Quizes
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

            var quizes = from q in _context.Quizes.Include(q => q.Conteudo) select q;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                quizes = quizes.Where(q => q.Titulo.Contains(pesquisa)).AsNoTracking();
            }

            int itensPorPagina = 12;

            return View(await quizes.ToPagedListAsync(pagina ?? 1, itensPorPagina));
        }

        // GET: Quizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizes
                .Include(q => q.Conteudo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // GET: Quizes/Create
        public IActionResult Create()
        {
            ViewData["ConteudoId"] = new SelectList(_context.Conteudos, "Id", "Titulo");
            return View();
        }

        // POST: Quizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,ConteudoId")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConteudoId"] = new SelectList(_context.Conteudos, "Id", "Titulo", quiz.ConteudoId);
            return View(quiz);
        }

        // GET: Quizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            ViewData["ConteudoId"] = new SelectList(_context.Conteudos, "Id", "Titulo", quiz.ConteudoId);
            return View(quiz);
        }

        // POST: Quizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,ConteudoId")] Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.Id))
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
            ViewData["ConteudoId"] = new SelectList(_context.Conteudos, "Id", "Titulo", quiz.ConteudoId);
            return View(quiz);
        }

        // GET: Quizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizes
                .Include(q => q.Conteudo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await _context.Quizes.FindAsync(id);
            _context.Quizes.Remove(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizExists(int id)
        {
            return _context.Quizes.Any(e => e.Id == id);
        }
    }
}
