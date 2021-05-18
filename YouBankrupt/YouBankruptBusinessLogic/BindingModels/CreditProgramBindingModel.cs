﻿using System.Collections.Generic;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class CreditProgramBindingModel
    {
        public int? Id { get; set; }

        public string CreditProgramName { get; set; }

        public double Persent { get; set; }

        public int PaymentTerm { get; set; }

        public Dictionary<int, (string, int)> Currenses { get; set; }

    }
}
