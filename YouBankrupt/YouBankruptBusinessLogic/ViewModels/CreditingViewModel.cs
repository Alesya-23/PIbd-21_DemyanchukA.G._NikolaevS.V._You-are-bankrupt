﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace YouBankruptBusinessLogic.ViewModels
{
    [DataContract]
    public class CreditingViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int CurrenceId { get; set; }

        [DisplayName("Дата выплаты")]
        public DateTime DateCredit { get; set; }

        [DisplayName("Валюта")]
        public string CurrenceName { get; set; }

        [DisplayName("Сумма")]
        public int Sum { get; set; }

        public Dictionary<int, int> CreditPayments{ get; set; }
    }
}
