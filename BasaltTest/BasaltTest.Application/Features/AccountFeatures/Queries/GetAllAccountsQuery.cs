using BasaltTest.Application.Interfaces;
using BasaltTest.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasaltTest.Application.Features.AccountFeatures.Queries
{
    public class GetAllAccountsQuery : IRequest<IEnumerable<Account>>
    {

        public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Account>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllAccountsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Account>> Handle(GetAllAccountsQuery query, CancellationToken cancellationToken)
            {
                var accountList = await _context.Accounts.ToListAsync();
                if (accountList == null)
                {
                    return null;
                }
                return accountList.AsReadOnly();
            }
        }
    }
}
