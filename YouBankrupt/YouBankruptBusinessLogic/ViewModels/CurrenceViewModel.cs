using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class CurrenceViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название валюты")]    
        public string CurrenceName { get; set; }

        [DisplayName("Курс валюты")]
        public string Rate { get; set; }
    }
}
