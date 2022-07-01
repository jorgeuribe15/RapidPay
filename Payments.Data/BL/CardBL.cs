using Payments.Data.PaymentsContext;
using Payments.Data.PaymentsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Data.BL
{
    public class CardBL : ICardBL
    {
        protected readonly RapidPayDbContext _context;
        private string newAccountNumber = string.Empty;
        const int maxCardLength = 14;
        int cont = 1;

        public CardBL(RapidPayDbContext rapidPayDbContext)
        {
            _context = rapidPayDbContext;
        }

        public async Task<string> CreateAccountNumber()
        {
            try
            {
                newAccountNumber = await CreateNewAccountNumber();

                if (_context.Cards.Any(c => c.AccountNumber == newAccountNumber))
                {
                    if(cont < 2)
                    {
                        await CreateAccountNumber();
                        cont++;
                    }
                    return "something went wrong pleae try again";
                }

                return newAccountNumber;
            }
            catch (Exception ex)
            {
                // log ex
                return null;
            }
        }

        private Task<string> CreateNewAccountNumber()
        {
            var cardNumber = new Random();

            for (int i = 0; i <= maxCardLength; i++)
            {
                newAccountNumber += cardNumber.Next(1, 9);
            }
            return Task.FromResult(newAccountNumber);
        }

        public async Task<Card> CreateCard(CardDTO card)
        {
            try
            {
                if (_context.Cards.Any(c => c.AccountNumber == card.AccountNumber))
                {
                    return null;
                }

                card.AccountNumber = await CreateAccountNumber();

                Card newCard = new Card()
                {
                    AccountNumber = card.AccountNumber,
                    Type = card.Type,
                    ExpirationDate = card.ExpirationDate,
                };

                await _context.Cards.AddAsync(newCard);
                await _context.SaveChangesAsync();

                return newCard;
            }
            catch (Exception ex)
            {
                // log ex
                return new Card();
            }
        }
    }
}
