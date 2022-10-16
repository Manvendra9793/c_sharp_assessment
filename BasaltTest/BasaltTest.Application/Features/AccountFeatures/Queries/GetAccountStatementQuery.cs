using Application.Features.AccountFeatures.Queries;
using BasaltTest.Application.Interfaces;
using BasaltTest.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasaltTest.Application.Features.AccountFeatures.Queries
{
    public class GetAccountStatementQuery: IRequest<IEnumerable<Transaction>>
    {
        public int Id { get; set; }
        public class GetAccountStatementQueryHandler : IRequestHandler<GetAccountStatementQuery, IEnumerable<Transaction>>
        {
            private readonly IApplicationDbContext _context;
            public GetAccountStatementQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Transaction>> Handle(GetAccountStatementQuery query, CancellationToken cancellationToken)
            {
                var transactions = _context.Transactions.Where(a => a.AccountId == query.Id).ToListAsync();
                if (transactions == null) return null;
                return null;
            }
        }
    }
}
