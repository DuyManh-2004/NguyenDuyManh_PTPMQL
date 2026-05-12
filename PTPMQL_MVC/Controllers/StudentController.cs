using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTPMQL_MVC.Data;
using PTPMQL_MVC.Models.Entities;
using PTPMQL_MVC.Models.ViewModels;
using ClosedXML.Excel;

namespace PTPMQL_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var result = await _context.Students
                            .Select(s => new StudentVM
                            {
                                StudentCode = s.StudentCode,
                                FullName = s.FullName,
                                FacultyName = s.Faculty!.FacultyName
                            })
                            .ToListAsync();
            return View(result);
        }
        public IActionResult DeleteAll()
{
    return View();
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteAllConfirmed()
{
    var students = await _context.Students.ToListAsync();

    _context.Students.RemoveRange(students);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}
    public IActionResult ImportExcel()
    {
        return View();
    }
    [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> ImportExcel(IFormFile file)
{
    if (file == null || file.Length == 0)
    {
        return Content("File không hợp lệ");
    }

    var students = new List<Student>();

    using (var stream = new MemoryStream())
{
    await file.CopyToAsync(stream);
    stream.Position = 0; // 🔥 QUAN TRỌNG

    using (var workbook = new XLWorkbook(stream))
    {
        var worksheet = workbook.Worksheets.First(); // 🔥 an toàn hơn

        var rows = worksheet.RowsUsed(); // 🔥 thay vì RangeUsed()

        foreach (var row in rows.Skip(1)) // bỏ header
        {
            var studentCode = row.Cell(1).GetValue<string>()?.Trim();
            var fullName = row.Cell(2).GetValue<string>()?.Trim();
            var facultyId = row.Cell(3).GetValue<string>()?.Trim();

            // bỏ dòng rỗng
            if (string.IsNullOrEmpty(studentCode) || string.IsNullOrEmpty(fullName))
                continue;

            // check trùng
            if (_context.Students.Any(s => s.StudentCode == studentCode))
                continue;

            if (!_context.Faculties.Any(f => f.FacultyId == facultyId))
            continue;

            students.Add(new Student
            {
                StudentCode = studentCode,
                FullName = fullName,
                FacultyId = facultyId
            });
        }
    }
}

_context.Students.AddRange(students);
await _context.SaveChangesAsync();

return RedirectToAction(nameof(Index));
}

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "FacultyId", "FacultyName");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentCode,FullName,FacultyId")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (StudentExists(student.StudentCode))
                {
                    ModelState.AddModelError("StudentCode", "Ma sinh vien da ton tai");
                    return View(student);
                }
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "FacultyId", "FacultyName", student.FacultyId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "FacultyId", "FacultyName", student.FacultyId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentCode,FullName,FacultyId")] Student student)
        {
            if (id != student.StudentCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentCode))
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
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "FacultyId", "FacultyName", student.FacultyId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentCode == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Students.Any(e => e.StudentCode == id);
        }
    }
}