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
    public class ContractTypesController : Controller
    {
        private readonly IContractTypeRepository _contractTypeRepository;

        public ContractTypesController(DataContext context, IContractTypeRepository contractTypeRepository)
        {
            _contractTypeRepository = contractTypeRepository;
        }

        // GET: ContractTypes
        public IActionResult Index()
        {
            return View(_contractTypeRepository.GetAll().OrderBy(x => x.Type));
        }

        // GET: ContractTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractType = await _contractTypeRepository.GetByIdAsync(id.Value);
            if (contractType == null)
            {
                return NotFound();
            }

            return View(contractType);
        }

        // GET: ContractTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContractTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContractType contractType)
        {
            if (ModelState.IsValid)
            {
                await _contractTypeRepository.CreateAsync(contractType);
                
                return RedirectToAction(nameof(Index));
            }
            return View(contractType);
        }

        // GET: ContractTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractType = await _contractTypeRepository.GetByIdAsync(id.Value);
            if (contractType == null)
            {
                return NotFound();
            }
            return View(contractType);
        }

        // POST: ContractTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContractType contractType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _contractTypeRepository.UpdateAsync(contractType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _contractTypeRepository.ExistAsync(contractType.Id))
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
            return View(contractType);
        }

        // GET: ContractTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractType = await _contractTypeRepository.GetByIdAsync(id.Value);
            if (contractType == null)
            {
                return NotFound();
            }

            return View(contractType);
        }

        // POST: ContractTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractType = await _contractTypeRepository.GetByIdAsync(id);
            await _contractTypeRepository.DeleteAsync(contractType);
            return RedirectToAction(nameof(Index));
        }
    }
}
