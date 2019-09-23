﻿using Microsoft.EntityFrameworkCore;
using ServicesAndRepos.Domain;

namespace ServicesAndRepos.DataAccess.EntityFramework
{
    public class ServicesAndReposContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
