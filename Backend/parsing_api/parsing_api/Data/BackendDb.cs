using Microsoft.EntityFrameworkCore;
using parsing_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parsing_api.Data
{
    public class BackendDb : DbContext
    {
        public DbSet<ParsingRequest> ParsingRequests { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Portal> Portals { get; set; }
        public DbSet<ParsingJob> ParsingJobs { get; set; }
        public BackendDb(DbContextOptions<BackendDb> options) : base(options) { }
    }
}
