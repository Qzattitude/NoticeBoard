using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoticeBoard.Controllers.Data;
using NoticeBoard.Models;

namespace NoticeBoard.Controllers
{
    public class NoticesController : Controller
    {
        private readonly AppDbContext _context;

        public NoticesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Notices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notice.ToListAsync());
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // GET: Notices/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Notices/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,NoticeName,NoticeLink,UploadTime,ViewCount")] Notice notice)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        notice.Id = Guid.NewGuid();
        //        _context.Add(notice);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(notice);
        //}

        //// GET: Notices/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var notice = await _context.Notice.FindAsync(id);
        //    if (notice == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(notice);
        //}

        // POST: Notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, string NoticeId)
        {
            if (id.ToString() != NoticeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var Notice = _context.Notice.Where(m => m.Id == id).FirstOrDefault();
                if (!Notice.Equals(null))
                {
                    Notice.ViewCount++; 
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index","");
        }

        //// GET: Notices/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var notice = await _context.Notice
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (notice == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(notice);
        //}

        //// POST: Notices/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var notice = await _context.Notice.FindAsync(id);
        //    _context.Notice.Remove(notice);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
