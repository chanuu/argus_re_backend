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
        public string Name { get; set; }
        public string Discription { get; set; }
        public double Price { get; set; }
        public string CoverImage { get; set; }
        
     
        public static Package Create( string name,  string discription, string coverImage, double price)
        {
            Package package = new Package()
            {               
                Name = name,                           
                CoverImage = coverImage,
                Price = price,
                Discription = discription
            };

            return package;

        }
    }
}
