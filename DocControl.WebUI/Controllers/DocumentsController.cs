using DocControl.Application.DTOs;
using DocControl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocControl.WebUI.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IDocumentService _documentService;
        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var documents = await _documentService.GetDocuments();
            return View(documents);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DocumentDTO document)
        {
            if (ModelState.IsValid)
            {
                await _documentService.Add(document);
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var documentDto = await _documentService.GetById(id);

            if (documentDto == null) return NotFound();

            return View(documentDto);

        }

        [HttpPost()]
        public async Task<IActionResult> Edit(DocumentDTO documentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _documentService.Update(documentDto);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(documentDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var documentDto = await _documentService.GetById(id);

            if (documentDto == null) return NotFound();

            return View(documentDto);

        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _documentService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
                return NotFound();

            var documentDto = await _documentService.GetById(id);

            if(documentDto == null)
                return NotFound();

            return View(documentDto);
        }
    }
}
