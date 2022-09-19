using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.DataBase.Models;

namespace TestTask.DataBase.Data
{
    public class TestTaskDbContext : DbContext
    {
        public TestTaskDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
