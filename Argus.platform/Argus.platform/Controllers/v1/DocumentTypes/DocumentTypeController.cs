using Argus.Platform.Application.Complience.DocumentTypes;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.DocumentTypes.DTOs;
using Argus.Platform.Core.Complience.Documents;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.DocumentTypes
{
    [ApiController]
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeService _documentTypeService;

        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        // Existing methods...

        [HttpPost(ApiRoutes.DocumentType.Create)]
        public async Task<IActionResult> CreateDocumentType([FromBody] DocumentTypeDto documentTypeDto)
        {
            if (documentTypeDto == null || string.IsNullOrWhiteSpace(documentTypeDto.Name))
            {
                return BadRequest("DocumentType information is not valid");
            }

            var documentType = new DocumentType { Name = documentTypeDto.Name };
            var createdDocumentType = await _documentTypeService.AddDocumentTypeAsync(documentType);
            return CreatedAtAction(nameof(ApiRoutes.DocumentType.Get), new { id = createdDocumentType.Id }, createdDocumentType);
        }

        [HttpPut(ApiRoutes.DocumentType.Update)]
        public async Task<IActionResult> UpdateDocumentType(Guid id, [FromBody] DocumentTypeDto documentTypeDto)
        {
            var existingDocumentType = await _documentTypeService.GetDocumentTypeAsync(id);
            if (existingDocumentType == null)
            {
                return NotFound($"DocumentType with ID {id} not found.");
            }

            if (documentTypeDto == null || string.IsNullOrWhiteSpace(documentTypeDto.Name))
            {
                return BadRequest("DocumentType information is not valid");
            }

            existingDocumentType.Name = documentTypeDto.Name;
            var updatedDocumentType = await _documentTypeService.UpdateDocumentTypeAsync(existingDocumentType);
            return Ok(updatedDocumentType);
        }

        [HttpGet(ApiRoutes.DocumentType.GetAll)]
        public async Task<IActionResult> GetAllDocumentTypes()
        {
            var documentTypes = await _documentTypeService.GetAllDocumentTypesAsync();
            return Ok(documentTypes);
        }

        [HttpGet(ApiRoutes.DocumentType.Get)]
        public async Task<IActionResult> GetDocumentType(Guid id)
        {
            var documentType = await _documentTypeService.GetDocumentTypeAsync(id);
            if (documentType == null)
            {
                return NotFound();
            }
            return Ok(documentType);
        }
    }
}
