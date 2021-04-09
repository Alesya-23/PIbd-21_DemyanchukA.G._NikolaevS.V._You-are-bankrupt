using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class Supplier
    {
        public int? Id { get; set; }

        [Required]
        public string SupplierFullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
