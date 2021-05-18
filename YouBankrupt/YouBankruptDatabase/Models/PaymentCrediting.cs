namespace YouBankruptDatabaseImplements.Models
{
    class PaymentCrediting
    {
        public int? Id { get; set; }

        public int? PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        public int? CreditingId { get; set; }

        public virtual Crediting Crediting { get; set; }
    }
}
