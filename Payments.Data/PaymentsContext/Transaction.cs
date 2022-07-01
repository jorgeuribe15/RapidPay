using System;
using System.Collections.Generic;

#nullable disable

namespace Payments.Data.PaymentsContext
{
    public partial class Transaction
    {
        public Transaction()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int ClientCardId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TraansactionPlace { get; set; }

        public virtual ClientCard ClientCard { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
