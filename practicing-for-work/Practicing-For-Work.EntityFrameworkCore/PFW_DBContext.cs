using Microsoft.EntityFrameworkCore;
using Practicing_For_Work.Domain.Entities;
using System;

namespace Practicing_For_Work.EntityFrameworkCore
{
    public partial class PFW_DBContext : DbContext
    {
        public PFW_DBContext(DbContextOptions<PFW_DBContext> options) 
            : base(options)
        {
        }

        public PFW_DBContext()
        {
        }

        public virtual DbSet<FdMember> FdMember { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FdMember>().ToTable("FdMember");
            
        }
    }
}
