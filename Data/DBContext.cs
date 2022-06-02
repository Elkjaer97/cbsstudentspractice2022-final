#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalPrac.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinalPrac.Data;

    public class DBContext : IdentityDbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<FinalPrac.Models.Profile> Profile { get; set; }

        public DbSet<FinalPrac.Models.Event> Event { get; set; }

        public DbSet<FinalPrac.Models.Comment> Comment { get; set; }

        public DbSet<FinalPrac.Models.Post> Post { get; set; }
    }
