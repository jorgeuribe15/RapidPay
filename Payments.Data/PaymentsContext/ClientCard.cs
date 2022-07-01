using System;
using System.Collections.Generic;

#nullable disable

namespace Payments.Data.PaymentsContext
{
    public partial class ClientCard
    {
        public ClientCard()
        {
            Credits = new HashSet<Credit>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int CardId { get; set; }
        public int ClientId { get; set; }
        public bool IsActive { get; set; }

        public virtual Card Card { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Credit> Credits { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
