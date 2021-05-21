using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class CurrenceBindingModel
    {
        public int? Id { get; set; }

        public int? SupplierId { get; set; }

        public string CurrenceName { get; set; }

        public string Rate { get; set; }
    }
}
