using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Data.PaymentsDtos
{
    public class CardDTO
    {       
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
