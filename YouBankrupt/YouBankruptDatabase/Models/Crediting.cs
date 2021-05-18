﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YouBankruptDatabaseImplements.Models;

namespace YouBankruptDatabaseImplements.Models
{
    public class Crediting
    {
        public int Id { get; set; }

        [Required]
        public int Sum { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("CurrenceCreditingId")]
        public virtual List<CurrenceCrediting> CurrenceCreditings { get; set; }

        [ForeignKey("CreditingId")]
        public virtual List<Payment> Payments { get; set; }

        [ForeignKey("CreditingId")]
        public virtual List<TransactionWithCustomer> TransactionWithCustomers { get; set; }
    }
}
