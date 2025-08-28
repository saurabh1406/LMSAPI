using LMSAPI.Domain.Entities;
using LMSP.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrasturcture
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {
        }

        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<MemberDetails> MemberDetails { get; set; }
        public DbSet<BookIssueDetails> BookIssueDetails { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserType> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // Configure your entity mappings here
        }
    
    }
}
