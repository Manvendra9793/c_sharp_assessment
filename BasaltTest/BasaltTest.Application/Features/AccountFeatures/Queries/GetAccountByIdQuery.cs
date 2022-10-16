﻿using BasaltTest.Application.Interfaces;
using BasaltTest.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasaltTest.Application.Features.AccountFeatures.Queries
{
    public class GetAccountByIdQuery : IRequest<Account>
    {
        public int Id { get; set; }
        public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Account>
        {
            private readonly IApplicationDbContext _context;
            public GetAccountByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Account> Handle(GetAccountByIdQuery query, CancellationToken cancellationToken)
            {
                var account = _context.Accounts.Where(a => a.Id == query.Id).FirstOrDefault();
                if (account == null) return null;
                return account;
            }
        }
    }
}
