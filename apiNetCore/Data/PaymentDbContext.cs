using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace apiNetCore.Data
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}