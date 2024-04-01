using Argus.Platform.Application.Complience;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Documents.DTOs;
using Argus.Platform.Core.Complience.Documents;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Documents
{
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet(ApiRoutes.Document.GetAll)]
        public async Task<IActionResult> GetAllDocuments()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents.Adapt<List<DocumentGetAllDto>>());
        }

        [HttpGet(ApiRoutes.Document.Get)]
        public async Task<IActionResult> GetDocument(Guid id)
        {
            var document = await _documentService.GetDocumentAsync(id);
            if (document is null)
            {
                return NotFound();
            }
            return Ok(document.Adapt<DocumentGetDto>());
        }

        [HttpPost(ApiRoutes.Document.Create)]
        public async Task<IActionResult> AddDocument(DocumentDto documentDto)
        {
            // Perform any necessary validation or mapping from DTO to entity
           
            var document =  documentDto.Adapt<Document>();
            var addedDocument = await _documentService.AddDocumentAsync(document);
            return CreatedAtAction(nameof(GetDocument), new { id = addedDocument.Id }, addedDocument);
        }

        [HttpPut(ApiRoutes.Document.Create)]
        public async Task<IActionResult> UpdateDocument(Guid id, DocumentDto documentDto)
        {
            var existingDocument = await _documentService.GetDocumentAsync(id);
            if (existingDocument == null)
            {
                return NotFound();
            }

            // Perform any necessary validation or mapping from DTO to entity
            existingDocument.Code = documentDto.Code;

            var updatedDocument = await _documentService.UpdateDocumentAsync(existingDocument);
            return Ok(updatedDocument);
        }

        [HttpPost(ApiRoutes.Document.Renew)]
        public async Task<IActionResult> AddDocumentRenewal(DocumentRenewalDto renewal)
        {
            var documentRenewal =   renewal.Adapt<DocumentRenewal>();
            await  _documentService.AddRenewalAsync(documentRenewal);
            return Ok(renewal);
        }
    }
}
