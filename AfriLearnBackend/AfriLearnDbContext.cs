﻿using AfriLearnBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AfriLearnBackend
{
    public class AfriLearnDbContext : IdentityDbContext<AppUser>
    {
        public AfriLearnDbContext(DbContextOptions<AfriLearnDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public  DbSet<Help>  HelpRequests { get; set; }
        public  DbSet<Message>  Messages { get; set; }
    }
   
}
