using Microsoft.EntityFrameworkCore;
using MUT_DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_DataAccess.DataContext
{
    public class MUTDbContext : DbContext
    {
        public MUTDbContext(DbContextOptions<MUTDbContext> options):base(options)
        {

        }
        public DbSet<Sport> Sports { get; set; }


    }
}
