using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432; User Id=postgres; Password=1234; Database=Tasinmaz");

            // veritabanı adresi girilecek
            //video 8 1.32
        }

        public DbSet<Tasinmaz> Tasinmaz { get; set; }
       
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Ilce> Ilce { get; set; }

        public DbSet<Mahalle> Mahalle { get; set; }

        public DbSet<Log> Log { get; set; }


        // public DbSet<Mahalle> Mahalle { get; set; }






        //public DbSet<OperationClaim> OperationClaims { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
    }
}
