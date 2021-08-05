using DocControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Document> Documents { get; set; } //Mapping ORM Class Document to table Documents

        protected override void OnModelCreating(ModelBuilder builder) //Configuring Model using Fluent API
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // builder.ApplyConfiguration(new CategoryConfiguration());
            // dont need because we use ApplyConfigurationsFromAssembly


        }
    }
}
