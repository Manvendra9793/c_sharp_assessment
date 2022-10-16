using BasaltTest.Application.Interfaces;
using BasaltTest.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasaltTest.Application.Features.AccountFeatures.Commands
{
    public class CreateAccountCommand : IRequest<int>
    {
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public int CustomerId { get; set; }
        public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
            {
                var account = new Account();
                account.AccountNumber = command.AccountNumber;
                account.AccountBalance = command.AccountBalance;
                account.CustomerId = command.CustomerId;
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                return account.Id;
            }
        }
    }
}
