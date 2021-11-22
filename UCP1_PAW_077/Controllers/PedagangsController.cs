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
    public class PedagangsController : Controller
    {
        private readonly JajananContext _context;

        public PedagangsController(JajananContext context)
        {
            _context = context;
        }

        // GET: Pedagangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedagangs.ToListAsync());
        }

        // GET: Pedagangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedagang = await _context.Pedagangs
                .FirstOrDefaultAsync(m => m.IdPedagang == id);
            if (pedagang == null)
            {
                return NotFound();
            }

            return View(pedagang);
        }

        // GET: Pedagangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedagangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedagang,Nama")] Pedagang pedagang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedagang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedagang);
        }

        // GET: Pedagangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedagang = await _context.Pedagangs.FindAsync(id);
            if (pedagang == null)
            {
                return NotFound();
            }
            return View(pedagang);
        }

        // POST: Pedagangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedagang,Nama")] Pedagang pedagang)
        {
            if (id != pedagang.IdPedagang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedagang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedagangExists(pedagang.IdPedagang))
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
            return View(pedagang);
        }

        // GET: Pedagangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedagang = await _context.Pedagangs
                .FirstOrDefaultAsync(m => m.IdPedagang == id);
            if (pedagang == null)
            {
                return NotFound();
            }

            return View(pedagang);
        }

        // POST: Pedagangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedagang = await _context.Pedagangs.FindAsync(id);
            _context.Pedagangs.Remove(pedagang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedagangExists(int id)
        {
            return _context.Pedagangs.Any(e => e.IdPedagang == id);
        }
    }
}
