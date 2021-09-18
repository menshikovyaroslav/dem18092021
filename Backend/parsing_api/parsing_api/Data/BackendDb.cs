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
        public DbSet<ParsingObject> ParsingObjects { get; set; }
        public BackendDb(DbContextOptions<BackendDb> options) : base(options) { }
    }
}
