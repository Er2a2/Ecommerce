using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B.E;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace DAL
{  
    public class DB : IdentityDbContext<UserApp>
    {
        public DB():base() { }
         public DB(DbContextOptions<DB> options):base(options) 
        {        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=Term2_N; Integrated Security=true; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Teacher> teachers { set; get; }
        public DbSet<course> course { set; get; }
        public DbSet<Teacher_course> teacher_Courses { set; get; }
        public DbSet<course_detailfile> course_detailfile { set; get;}
        public DbSet<Order_Course> Order_Courses { set; get; }
        public DbSet<Order>Orders { set; get; }
        

    }
}
