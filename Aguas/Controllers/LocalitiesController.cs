using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aguas.Data;
using Aguas.Data.Entities;
using Aguas.Data.Repositories;

namespace Aguas.Controllers
{
    public class LocalitiesController : Controller
    {
        private readonly ILocalityRepository _localityRepository;

        public LocalitiesController(DataContext context, ILocalityRepository localityRepository)
        {
            _localityRepository = localityRepository;
        }

        // GET: Localities
        public IActionResult Index()
        {
            return View(_localityRepository.GetAll().OrderBy(x => x.Address));
        }

        // GET: Localities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locality = await _localityRepository.GetByIdAsync(id.Value);
            if (locality == null)
            {
                return NotFound();
            }

            return View(locality);
        }

        // GET: Localities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Locality locality)
        {
            if (ModelState.IsValid)
            {
                await _localityRepository.CreateAsync(locality);

                return RedirectToAction(nameof(Index));
            }
            return View(locality);
        }

        // GET: Localities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locality = await _localityRepository.GetByIdAsync(id.Value);
            if (locality == null)
            {
                return NotFound();
            }
            return View(locality);
        }

        // POST: Localities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Locality locality)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _localityRepository.UpdateAsync(locality);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _localityRepository.ExistAsync(locality.Id))
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
            return View(locality);
        }

        // GET: Localities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locality = await _localityRepository.GetByIdAsync(id.Value);
            if (locality == null)
            {
                return NotFound();
            }

            return View(locality);
        }

        // POST: Localities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locality = await _localityRepository.GetByIdAsync(id);
            await _localityRepository.DeleteAsync(locality);
            return RedirectToAction(nameof(Index));
        }
    }
}
