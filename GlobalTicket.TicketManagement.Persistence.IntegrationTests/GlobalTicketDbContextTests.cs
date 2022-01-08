﻿using GlobalTicket.TicketManagement.Application.Contracts;
using GlobalTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GlobalTicket.TicketManagement.Persistence.IntegrationTests
{
    public class GlobalTicketDbContextTests
    {
        private readonly GlobalTicketDbContext _globalTicketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public GlobalTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GlobalTicketDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

             _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _globalTicketDbContext = new GlobalTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            _globalTicketDbContext.Events.Add(ev);
            await _globalTicketDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
