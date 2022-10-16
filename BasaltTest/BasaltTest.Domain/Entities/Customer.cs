using BasaltTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaltTest.Domain.Entities
{
    public class Customer: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
