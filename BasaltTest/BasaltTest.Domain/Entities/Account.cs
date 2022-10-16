using BasaltTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaltTest.Domain.Entities
{
    public class Account: BaseEntity
    {
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}
