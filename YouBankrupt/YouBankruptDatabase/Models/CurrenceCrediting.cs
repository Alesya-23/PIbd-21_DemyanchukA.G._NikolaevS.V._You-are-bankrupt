namespace YouBankruptDatabaseImplements.Models
{
    public class CurrenceCrediting
    {
        public int Id { get; set; }

        public int CurrenceCId { get; set; }

        public int CreditingId { get; set; }

        public virtual Currence Procedure { get; set; }

        public virtual Crediting Visit { get; set; }
    }
}
