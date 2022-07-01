using Microsoft.EntityFrameworkCore;
using Payments.Data.PaymentsContext;
using Payments.Data.PaymentsDtos;
using Payments.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Data.BL
{
    public class PaymentsBL : IPaymentsBL
    {
        protected readonly RapidPayDbContext _context;
        private IUFEs _uFEs;
        Transaction transaction;

        public PaymentsBL(RapidPayDbContext rapidPayDbContext, IUFEs uFEs)
        {
            _context = rapidPayDbContext;
            _uFEs = uFEs;
        }
        private async Task<Transaction> GetTransaction(TransactionDTO transactiondto)
        {
            transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == transactiondto.Id && t.ClientCardId == transactiondto.ClientCardId);
            if(transaction == null)
            {
                return null;
            }

            return transaction;
        }

        public async Task<Payment> SetPayment(TransactionDTO transaction)
        {   
            try
            {
                // Validate if transaccition is paid
                if(_context.Payments.Any(p => p.TransactionId == transaction.Id))
                {
                    return null;
                }

                // validate if trasaction exists
                await GetTransaction(transaction);

                if (transaction == null)
                {
                    return null; ;
                }

                
                // GET UEF
                int fee = _uFEs.GetUfeValue();
                // set payment
                Payment payment = new Payment
                {
                    PaymentFee = fee == 0 ? transaction.Amount : transaction.Amount * (decimal)(1 * fee),
                    TransactionId = transaction.Id,
                    Amount = transaction.Amount,
                    Ufe = fee,
                    PaymentDate = DateTime.Now,
                };

                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();

                return payment;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<decimal> GetBalanceByAccountNumber(string accountNumber)
        {
            int cardid = await _context.Cards.Include(i => i.ClientCards).Where(c => c.AccountNumber == accountNumber).Select(s => s.ClientCards.FirstOrDefault().Id).FirstOrDefaultAsync();

            if(cardid == 0)
            {
                return 0;
            }
            else
            {
                decimal creditAmmount = _context.ClientCards.Include(i => i.Credits).Where(c => c.CardId == cardid).Select(s => s.Credits.FirstOrDefault().CreditAmount).FirstOrDefault();
                var totalPayments = (from t in _context.Transactions
                                         join p in _context.Payments on t.Id equals p.TransactionId
                                         where t.ClientCardId == cardid
                                         select new
                                         {
                                             p.PaymentFee
                                         }).Sum(s => s.PaymentFee);

                decimal balance = creditAmmount - totalPayments;

                return balance;
            }
        }

    }
}
