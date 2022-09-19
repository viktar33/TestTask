using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.CQRS.Features.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public DeleteEmployeeCommand(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
