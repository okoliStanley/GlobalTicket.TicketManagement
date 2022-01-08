using GlobalTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Identity
{
    public class GlobalTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public GlobalTicketIdentityDbContext(DbContextOptions<GlobalTicketIdentityDbContext> options) : base(options)
        {

        }
    }
}
