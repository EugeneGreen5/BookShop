﻿using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
