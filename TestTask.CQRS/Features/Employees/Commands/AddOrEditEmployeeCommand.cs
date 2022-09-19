using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DataBase.Models;

namespace TestTask.CQRS.Features.Employees.Commands
{
    public class AddOrEditEmployeeCommand : IRequest<int>
    {
        public AddOrEditEmployeeCommand(Employee employee)
        {
            Employee = employee;
        }
        public Employee? Employee { get; set; }
    }
}
