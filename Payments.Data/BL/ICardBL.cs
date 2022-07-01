using Payments.Data.PaymentsContext;
using Payments.Data.PaymentsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Data.BL
{
    public interface ICardBL
    {
        Task<string> CreateAccountNumber();
        Task<Card> CreateCard(CardDTO card);
    }
}
