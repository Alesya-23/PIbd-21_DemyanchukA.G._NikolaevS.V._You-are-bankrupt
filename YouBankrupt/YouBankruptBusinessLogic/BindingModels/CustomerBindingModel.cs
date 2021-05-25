using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class CustomerBindingModel
    {
        public int? Id { get; set; }

        public string CustomerFullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
