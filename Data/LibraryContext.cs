﻿using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Vasiliu_Adrian_Lab2.Models;
using Publisher = Vasiliu_Adrian_Lab2.Models.Publisher;

namespace Vasiliu_Adrian_Lab2.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) :
       base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublishedBook> PublishedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<PublishedBook>().ToTable("PublishedBook");
            modelBuilder.Entity<PublishedBook>()
                .HasKey(c => new { c.BookID, c.PublisherID });//configureaza cheia primara compusa
        }

        public DbSet<Vasiliu_Adrian_Lab2.Models.Author> Author { get; set; }
    }
}