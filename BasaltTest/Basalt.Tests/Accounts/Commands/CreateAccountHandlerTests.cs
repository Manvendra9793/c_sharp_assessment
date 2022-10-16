using Basalt.Tests.Mocks;
using BasaltTest.Application.Features.AccountFeatures.Queries;
using BasaltTest.Application.Interfaces;
using BasaltTest.Domain.Entities;
using Shouldly;
using System.Collections.ObjectModel;
using static BasaltTest.Application.Features.AccountFeatures.Queries.GetAllAccountsQuery;

namespace Basalt.Tests.Accounts.Commands
{
    public class CreateAccountHandlerTests
    {
        private readonly IApplicationDbContext _mockDbContext;

        public CreateAccountHandlerTests()
        {
            _mockDbContext = MockDBContext.GetDbContext().Object;
        }

        [Fact]
        public async Task GetAllAccountsTest()
        {
            var handler = new GetAllAccountsQueryHandler(_mockDbContext);
            var result = await handler.Handle(new GetAllAccountsQuery(), CancellationToken.None);
            result.ShouldBeOfType<IEnumerable<Account>>();
            //result.ShouldBeOfType<ReadOnlyCollection<IEnumerable<Account>>>();
            //result.Accounts.Count.ShouldBe(2);
        }
    }
}
