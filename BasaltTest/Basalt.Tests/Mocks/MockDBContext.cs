using BasaltTest.Application.Interfaces;
using BasaltTest.Domain.Entities;
using BasaltTest.Persitence.Context;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basalt.Tests.Mocks
{
    public class MockDBContext
    {
        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            return dbSet.Object;
        }
        public static Mock<IApplicationDbContext> GetDbContext()
        {
         
            List<Account> accounts = new List<Account>
            {
                new Account{ Id = 1, AccountNumber="A001",AccountBalance=300,CustomerId=1},
                new Account{ Id = 2, AccountNumber="A002",AccountBalance=400,CustomerId=2}
            };
            var mockDbContext = new Mock<IApplicationDbContext>();
            mockDbContext.Setup(p => p.Accounts).Returns(GetQueryableMockDbSet<Account>(accounts));
            return mockDbContext;
        }
    }
}
