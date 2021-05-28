﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class CreditProgramBindingModel
    {
        public int? Id { get; set; }

        public int? TranzactionId { get; set; }

        public int? SupplierId { get; set; }

        public string CreditProgramName { get; set; }

        public double Persent { get; set; }

        public int PaymentTerm { get; set; }
        public Dictionary<int, string> Currenses { get; set; }

    }
}
