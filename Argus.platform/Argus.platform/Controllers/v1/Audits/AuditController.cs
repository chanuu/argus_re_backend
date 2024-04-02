﻿using Argus.Platform.Application.Complience.Audits;
using Argus.Platform.Controllers.v1.Audits.DTOs;
using Argus.Platform.Core.Complience.Audits;
using Argus.Platform.Infrastructure.Persistance.Repository.Audits;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Audits
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditController : ControllerBase
    {
        private readonly IAuditService _auditService;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var audits = await _auditService.GetAllAuditsAsync();
            return Ok(audits.Adapt<List<AuditListDto>>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var audit = await _auditService.GetAuditByIdAsync(id);
            if (audit == null)
            {
                return NotFound();
            }
            return Ok(audit.Adapt<GetAuditDto>());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuditInputDto auditDto)
        {
           var audit =  auditDto.Adapt<Audit>();
            var createdAudit = await _auditService.AddAuditAsync(audit);
            return CreatedAtAction(nameof(GetById), new { id = createdAudit.Id }, createdAudit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Audit audit)
        {
            if (id != audit.Id)
            {
                return BadRequest();
            }

            var updatedAudit = await _auditService.UpdateAuditAsync(audit);
            return Ok(updatedAudit);
        }
        [HttpPost("{auditId}/requirements")]
        public async Task<IActionResult> AddAuditRequirement(Guid auditId, [FromBody] AuditRequirements auditRequirement)
        {
            await _auditService.AddAuditRequirementAsync(auditId, auditRequirement);
            return Ok();
        }

        [HttpDelete("{auditId}/requirements/{requirementId}")]
        public async Task<IActionResult> RemoveAuditRequirement(Guid auditId, Guid requirementId)
        {
            await _auditService.RemoveAuditRequirementAsync(auditId, requirementId);
            return Ok();
        }
    }
}