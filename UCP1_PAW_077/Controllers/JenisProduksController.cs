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
    public class JenisProduksController : Controller
    {
        private readonly JajananContext _context;

        public JenisProduksController(JajananContext context)
        {
            _context = context;
        }

        // GET: JenisProduks
        public async Task<IActionResult> Index()
        {
            return View(await _context.JenisProduks.ToListAsync());
        }

        // GET: JenisProduks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisProduk = await _context.JenisProduks
                .FirstOrDefaultAsync(m => m.KodeJenisProduk == id);
            if (jenisProduk == null)
            {
                return NotFound();
            }

            return View(jenisProduk);
        }

        // GET: JenisProduks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JenisProduks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KodeJenisProduk,Nama")] JenisProduk jenisProduk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jenisProduk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jenisProduk);
        }

        // GET: JenisProduks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisProduk = await _context.JenisProduks.FindAsync(id);
            if (jenisProduk == null)
            {
                return NotFound();
            }
            return View(jenisProduk);
        }

        // POST: JenisProduks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KodeJenisProduk,Nama")] JenisProduk jenisProduk)
        {
            if (id != jenisProduk.KodeJenisProduk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jenisProduk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JenisProdukExists(jenisProduk.KodeJenisProduk))
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
            return View(jenisProduk);
        }

        // GET: JenisProduks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisProduk = await _context.JenisProduks
                .FirstOrDefaultAsync(m => m.KodeJenisProduk == id);
            if (jenisProduk == null)
            {
                return NotFound();
            }

            return View(jenisProduk);
        }

        // POST: JenisProduks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jenisProduk = await _context.JenisProduks.FindAsync(id);
            _context.JenisProduks.Remove(jenisProduk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JenisProdukExists(int id)
        {
            return _context.JenisProduks.Any(e => e.KodeJenisProduk == id);
        }
    }
}
