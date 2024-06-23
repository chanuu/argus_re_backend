using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Packages
{
    public class Package : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public double Price { get; set; }
        public string CoverImage { get; set; }
        

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public Guid BranchId { get; set; }
        public static Package Create( string name, Guid tenantId, string discription, string coverImage, double price, Guid branchId)
        {
            Package package = new Package()
            {
                TenantId = tenantId,
                Name = name,             
                BranchId = branchId,
                CoverImage = coverImage,
                Price = price,
                Discription = discription
            };

            return package;

        }
    }
}
