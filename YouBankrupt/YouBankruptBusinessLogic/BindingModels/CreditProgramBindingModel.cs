using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    class CreditProgramBindingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Persent { get; set; }

        public int PaymentTerm { get; set; }

        //связь с валютой
    }
}
