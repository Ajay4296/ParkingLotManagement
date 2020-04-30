using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.UserDBContext
{
   public class UserDbContext:DbContext
    { 
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<ParkingModel> ParkingSpace { set; get; }
    }
}
