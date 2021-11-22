using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_077.Models;

namespace UCP1_PAW_077.Controllers
{
    public class TestimonisController : Controller
    {
        private readonly JajananContext _context;

        public TestimonisController(JajananContext context)
        {
            _context = context;
        }

        // GET: Testimonis
        public async Task<IActionResult> Index()
        {
            var jajananContext = _context.Testimonis.Include(t => t.IdTestimoniNavigation).Include(t => t.KodeJenisProdukNavigation);
            return View(await jajananContext.ToListAsync());
        }

        // GET: Testimonis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimoni = await _context.Testimonis
                .Include(t => t.IdTestimoniNavigation)
                .Include(t => t.KodeJenisProdukNavigation)
                .FirstOrDefaultAsync(m => m.IdTestimoni == id);
            if (testimoni == null)
            {
                return NotFound();
            }

            return View(testimoni);
        }

        // GET: Testimonis/Create
        public IActionResult Create()
        {
            ViewData["IdTestimoni"] = new SelectList(_context.Produks, "KodeProduk", "KodeProduk");
            ViewData["KodeJenisProduk"] = new SelectList(_context.JenisProduks, "KodeJenisProduk", "KodeJenisProduk");
            return View();
        }

        // POST: Testimonis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTestimoni,Nama,Deskripsi,KodeJenisProduk,KodeProduk")] Testimoni testimoni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testimoni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTestimoni"] = new SelectList(_context.Produks, "KodeProduk", "KodeProduk", testimoni.IdTestimoni);
            ViewData["KodeJenisProduk"] = new SelectList(_context.JenisProduks, "KodeJenisProduk", "KodeJenisProduk", testimoni.KodeJenisProduk);
            return View(testimoni);
        }

        // GET: Testimonis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimoni = await _context.Testimonis.FindAsync(id);
            if (testimoni == null)
            {
                return NotFound();
            }
            ViewData["IdTestimoni"] = new SelectList(_context.Produks, "KodeProduk", "KodeProduk", testimoni.IdTestimoni);
            ViewData["KodeJenisProduk"] = new SelectList(_context.JenisProduks, "KodeJenisProduk", "KodeJenisProduk", testimoni.KodeJenisProduk);
            return View(testimoni);
        }

        // POST: Testimonis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTestimoni,Nama,Deskripsi,KodeJenisProduk,KodeProduk")] Testimoni testimoni)
        {
            if (id != testimoni.IdTestimoni)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testimoni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimoniExists(testimoni.IdTestimoni))
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
            ViewData["IdTestimoni"] = new SelectList(_context.Produks, "KodeProduk", "KodeProduk", testimoni.IdTestimoni);
            ViewData["KodeJenisProduk"] = new SelectList(_context.JenisProduks, "KodeJenisProduk", "KodeJenisProduk", testimoni.KodeJenisProduk);
            return View(testimoni);
        }

        // GET: Testimonis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimoni = await _context.Testimonis
                .Include(t => t.IdTestimoniNavigation)
                .Include(t => t.KodeJenisProdukNavigation)
                .FirstOrDefaultAsync(m => m.IdTestimoni == id);
            if (testimoni == null)
            {
                return NotFound();
            }

            return View(testimoni);
        }

        // POST: Testimonis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testimoni = await _context.Testimonis.FindAsync(id);
            _context.Testimonis.Remove(testimoni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestimoniExists(int id)
        {
            return _context.Testimonis.Any(e => e.IdTestimoni == id);
        }
    }
}
