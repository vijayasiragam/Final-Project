using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class PAdminController : Controller
    {
        private readonly LunchContext _context;

        public PAdminController(LunchContext context)
        {
            _context = context;
        }

        // GET: PAdmin
        public async Task<IActionResult> Index()
        {
            return View(await _context.PAdmins.ToListAsync());
        }

        // GET: PAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pAdmin = await _context.PAdmins
                .FirstOrDefaultAsync(m => m.SchoolId == id);
            if (pAdmin == null)
            {
                return NotFound();
            }

            return View(pAdmin);
        }

        // GET: PAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolId,SchoolName")] PAdmin pAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pAdmin);
        }

        // GET: PAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pAdmin = await _context.PAdmins.FindAsync(id);
            if (pAdmin == null)
            {
                return NotFound();
            }
            return View(pAdmin);
        }

        // POST: PAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchoolId,SchoolName")] PAdmin pAdmin)
        {
            if (id != pAdmin.SchoolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PAdminExists(pAdmin.SchoolId))
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
            return View(pAdmin);
        }

        // GET: PAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pAdmin = await _context.PAdmins
                .FirstOrDefaultAsync(m => m.SchoolId == id);
            if (pAdmin == null)
            {
                return NotFound();
            }

            return View(pAdmin);
        }

        // POST: PAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pAdmin = await _context.PAdmins.FindAsync(id);
            _context.PAdmins.Remove(pAdmin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PAdminExists(int id)
        {
            return _context.PAdmins.Any(e => e.SchoolId == id);
        }
    }
}
