using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTPMQL_MVC.Data;
using PTPMQL_MVC.Models.Entities;

namespace PTPMQL_MVC.Controllers
{
    public class ImportDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImportDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ImportDetail
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ImportDetails.Include(i => i.Device).Include(i => i.ImportReceipt);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ImportDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importDetail = await _context.ImportDetails
                .Include(i => i.Device)
                .Include(i => i.ImportReceipt)
                .FirstOrDefaultAsync(m => m.ImportDetailID == id);
            if (importDetail == null)
            {
                return NotFound();
            }

            return View(importDetail);
        }

        // GET: ImportDetail/Create
        public IActionResult Create()
        {
            ViewData["DeviceID"] = new SelectList(_context.Devices, "DeviceID", "DeviceName");
            ViewData["ImportReceiptID"] = new SelectList(_context.ImportReceipts, "ImportReceiptID", "ImportReceiptID");
            return View();
        }

        // POST: ImportDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImportDetailID,ImportReceiptID,DeviceID,UnitPrice,Quantity,TotalMoney")] ImportDetail importDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceID"] = new SelectList(_context.Devices, "DeviceID", "DeviceName", importDetail.DeviceID);
            ViewData["ImportReceiptID"] = new SelectList(_context.ImportReceipts, "ImportReceiptID", "ImportReceiptID", importDetail.ImportReceiptID);
            return View(importDetail);
        }

        // GET: ImportDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importDetail = await _context.ImportDetails.FindAsync(id);
            if (importDetail == null)
            {
                return NotFound();
            }
            ViewData["DeviceID"] = new SelectList(_context.Devices, "DeviceID", "DeviceName", importDetail.DeviceID);
            ViewData["ImportReceiptID"] = new SelectList(_context.ImportReceipts, "ImportReceiptID", "ImportReceiptID", importDetail.ImportReceiptID);
            return View(importDetail);
        }

        // POST: ImportDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImportDetailID,ImportReceiptID,DeviceID,UnitPrice,Quantity,TotalMoney")] ImportDetail importDetail)
        {
            if (id != importDetail.ImportDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportDetailExists(importDetail.ImportDetailID))
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
            ViewData["DeviceID"] = new SelectList(_context.Devices, "DeviceID", "DeviceName", importDetail.DeviceID);
            ViewData["ImportReceiptID"] = new SelectList(_context.ImportReceipts, "ImportReceiptID", "ImportReceiptID", importDetail.ImportReceiptID);
            return View(importDetail);
        }

        // GET: ImportDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importDetail = await _context.ImportDetails
                .Include(i => i.Device)
                .Include(i => i.ImportReceipt)
                .FirstOrDefaultAsync(m => m.ImportDetailID == id);
            if (importDetail == null)
            {
                return NotFound();
            }

            return View(importDetail);
        }

        // POST: ImportDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var importDetail = await _context.ImportDetails.FindAsync(id);
            if (importDetail != null)
            {
                _context.ImportDetails.Remove(importDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportDetailExists(int id)
        {
            return _context.ImportDetails.Any(e => e.ImportDetailID == id);
        }
    }
}
