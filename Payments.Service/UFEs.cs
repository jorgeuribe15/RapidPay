using System;
using System.Collections.Generic;

namespace Payments.Service
{
    public class UFEs : IUFEs
    {
        private List<int> ufes = new List<int>();
        private int nextUfe = 0;
        int value = 0;

        public UFEs()
        {
            ufes.Add(0);
            ufes.Add(1);
            ufes.Add(2);
        }
        public int GetUfeValue()
        {
            var rUfes = new Random();
            nextUfe = rUfes.Next(0, 3);

            value = ufes[nextUfe];

            return value;
        }
    }
}
