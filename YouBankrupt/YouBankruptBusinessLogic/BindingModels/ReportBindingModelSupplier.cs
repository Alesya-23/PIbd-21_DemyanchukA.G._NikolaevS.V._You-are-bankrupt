using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class ReportBindingModelSupplier
    {
        public string FileName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? SupplierId { get; set; }
        
    }
}
