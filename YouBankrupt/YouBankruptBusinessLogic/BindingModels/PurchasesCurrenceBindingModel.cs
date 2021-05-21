using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class PurchasesCurrenceBindingModel
    {
        public int? Id { get; set; }

        public int? SupplierId { get; set; }

        public string PurchasesName { get; set;}
 
        public DateTime DateBuy { get; set; }

        public double Summ { get; set; }

        public Dictionary<int, (string, int)> Currenses { get; set; }
    }
}
