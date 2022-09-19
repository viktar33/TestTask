using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.CQRS.Features.Employees.Querries;
using TestTask.DataBase.Data;
using TestTask.DataBase.Models;

namespace TestTask.CQRS.Features.Employees.Handlers.QuerriesHandlers
{
    internal class GetEmployeeByIdQuerryHandler : IRequestHandler<GetEmployeeByIdQuerry,Employee>
    {
        private readonly TestTaskDbContext context;

        public GetEmployeeByIdQuerryHandler(TestTaskDbContext context)
        {
            this.context = context;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuerry request, CancellationToken cancellationToken)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            return employee;
        }
    }
}
