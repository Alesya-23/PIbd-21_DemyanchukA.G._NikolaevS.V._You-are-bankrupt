using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class PurchasesCurrenceViewModel
    {
        public int Id { get; set; }

        public int? SupplierId { get; set; }
        [DisplayName("Название закупки")]
        public string PurchasesName { get; set; }

        [DisplayName("Дата закупки")]
        public DateTime DateBuy { get; set; }

        public Dictionary<int, (string, int)> Currenses { get; set; }
    }
}
