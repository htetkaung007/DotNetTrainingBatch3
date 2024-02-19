using DotNetTrainingBatch3.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.EfcoreExamples
{
    public class AppDbContext : DbContext //take inheightlight in class
    {
        //In DbContext has override
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//built connection with DataBase
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-BMOLS6N",//sever name
                InitialCatalog = "TestDb",//Data Base Name
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);//connection 
        }
        //mapping
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
