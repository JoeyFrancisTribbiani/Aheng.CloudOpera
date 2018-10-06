using Aheng.CloudOpera.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aheng.CloudOpera.Infrastructrue.DataBase
{
    public class OperaContext : DbContext
    {
        public OperaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos{ get; set; }
    }
}
