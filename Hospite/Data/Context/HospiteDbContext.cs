using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospite.Data.Context
{
    public class HospiteDbContext: IdentityDbContext<AppUser>
    {

        public HospiteDbContext(DbContextOptions<HospiteDbContext> options) : base(options)
        {

        }
        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }


    }
}
