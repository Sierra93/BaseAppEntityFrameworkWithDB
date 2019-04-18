using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestAsp.NetCoreMvc.Models {
    //модель необходимая для работы с Entity Framework
    public class MobileContext : DbContext {
        public DbSet<Phone> Phones { get; set; }
        public MobileContext(DbContextOptions<MobileContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
