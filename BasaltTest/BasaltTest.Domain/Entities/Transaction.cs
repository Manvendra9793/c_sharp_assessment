using BasaltTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaltTest.Domain.Entities
{
    public class Transaction: BaseEntity
    {
        
        public int TransactionType {get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
