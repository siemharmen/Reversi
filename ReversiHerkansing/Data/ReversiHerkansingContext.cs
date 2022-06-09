    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReversiHerkansing.Model;

namespace ReversiHerkansing.Data
{
    public class ReversiHerkansingContext : DbContext
    {
        public ReversiHerkansingContext (DbContextOptions<ReversiHerkansingContext> options)
            : base(options)
        {
        }

        public DbSet<ReversiHerkansing.Model.Spel> Spellen { get; set; }
        public DbSet<ReversiHerkansing.Model.Board> Boards { get; set; }
        public DbSet<ReversiHerkansing.Model.ReversiInfo> ReversiInfo { get; set; }

    }
}
