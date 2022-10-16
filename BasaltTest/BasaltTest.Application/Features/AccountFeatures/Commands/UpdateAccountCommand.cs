using BasaltTest.Application.Interfaces;
using BasaltTest.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasaltTest.Application.Features.AccountFeatures.Commands
{
    public class UpdateAccountCommand : IRequest<int>
    {
        public int Id { get; set; }
        public decimal AccountBalance { get; set; }
        public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
            {
                var account = _context.Accounts.Where(a => a.Id == command.Id).FirstOrDefault();

                if (account == null)
                {
                    return default;
                }
                else
                {
                    account.AccountBalance = command.AccountBalance;
                    await _context.SaveChangesAsync();
                    return account.Id;
                }
            }
        }
    }
}
