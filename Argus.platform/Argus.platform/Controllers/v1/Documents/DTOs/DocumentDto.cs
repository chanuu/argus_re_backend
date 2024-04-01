using Argus.Platform.Core.Complience.Documents;
using System.Xml.Linq;

namespace Argus.Platform.Controllers.v1.Documents.DTOs
{
    public record DocumentDto(
    string Code,
    string Name,
    Guid TenantId,
    string AccessLevel,
    int ValidPeriod,
    string Description,
    DateTime? IssueDate,
    int AlertBefore,
    bool IsExpired,
    DocumentStatus Status,
    Guid DocumentTypeId,
    bool IsRenewable,
    bool IsReviewable,
    int ReviewInterval
    );

    public record DocumentType(string Name);

    public record DocumentGetAllDto(
        Guid Id ,
        string Code,
        string Name,
        Guid TenantId,
        string AccessLevel,
        int ValidPeriod,
        string Description,
        DateTime? IssueDate,
        int AlertBefore,
        bool IsExpired,
        string Status,
        DocumentType DocumentTypes
        
        );
    public record DocumentGetDto(
       Guid Id,
       string Code,
       string Name,
       Guid TenantId,
       string AccessLevel,
       int ValidPeriod,
       string Description,
       DateTime? IssueDate,
       int AlertBefore,
       bool IsExpired,
       string Status,
       DocumentType DocumentTypes,
       List<GetDocumentRenewalDto> DocumentRenewal,
       bool IsRenewable,
       bool IsReviewable,
       int ReviewInterval
       );

    public record DocumentRenewalDto(
          int TenantId,
          DateTime? FromDate,
          DateTime? ExpireDate,
          string ScanCopy,
          Guid DocumentId,
          DocumentStatus Status);

    public record GetDocumentRenewalDto(
         int TenantId,
         DateTime? FromDate,
         DateTime? ExpireDate,
         string ScanCopy,
         Guid DocumentId,
         string Status);




}
