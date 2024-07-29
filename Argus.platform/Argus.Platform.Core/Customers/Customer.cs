using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Customers
{
    public class Customer: BaseEntity
    {
      
        public string Note{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Status Status { get; set; }

        public static Customer Create(string note, string name,  string email, string contactNo, Status status )
        {
            Customer customer = new Customer()
            {
              
                Name = name,
                Email = email,
                ContactNo = contactNo,
                Note = note,
                Status = status,
               
            };

            return customer;

        }
    }
}
