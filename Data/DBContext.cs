#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalPrac.Models;



    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<FinalPrac.Models.Profile> Profile { get; set; }

        public DbSet<FinalPrac.Models.Event> Event { get; set; }
    }
