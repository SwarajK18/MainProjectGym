using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainProjectGym.DAL.Data;
using MainProjectGym.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace MainProjectGym.Controllers
{
    [Authorize]
    public class MembershipDetailsController : Controller
    {
        private readonly MainProjectGymDbContext _context;

        public MembershipDetailsController(MainProjectGymDbContext context)
        {
            _context = context;
        }

        // GET: MembershipDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Memberships.ToListAsync());
        }

        // GET: MembershipDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membershipDetails = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MembershipDetailsId == id);
            if (membershipDetails == null)
            {
                return NotFound();
            }

            return View(membershipDetails);
        }

        // GET: MembershipDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembershipDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembershipDetailsId,MembershipName,MembershipDetail,Price,IsActive,Sequence")] MembershipDetails membershipDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membershipDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membershipDetails);
        }

        // GET: MembershipDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membershipDetails = await _context.Memberships.FindAsync(id);
            if (membershipDetails == null)
            {
                return NotFound();
            }
            return View(membershipDetails);
        }

        // POST: MembershipDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembershipDetailsId,MembershipName,MembershipDetail,Price,IsActive,Sequence")] MembershipDetails membershipDetails)
        {
            if (id != membershipDetails.MembershipDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membershipDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipDetailsExists(membershipDetails.MembershipDetailsId))
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
            return View(membershipDetails);
        }

        // GET: MembershipDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membershipDetails = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MembershipDetailsId == id);
            if (membershipDetails == null)
            {
                return NotFound();
            }

            return View(membershipDetails);
        }

        // POST: MembershipDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membershipDetails = await _context.Memberships.FindAsync(id);
            _context.Memberships.Remove(membershipDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipDetailsExists(int id)
        {
            return _context.Memberships.Any(e => e.MembershipDetailsId == id);
        }
    }
}
