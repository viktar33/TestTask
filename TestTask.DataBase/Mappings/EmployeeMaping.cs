using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DataBase.Models;

namespace TestTask.DataBase.Mappings
{
        public class EmployeeMapping : IEntityTypeConfiguration<Employee>
        {
            public void Configure(EntityTypeBuilder<Employee> builder)
            {
                builder
                     .ToTable("");
                builder
                    .HasKey(x => x.Id);
            }
        }
}
