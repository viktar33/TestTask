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
    internal class GetAllEmployeesQuerryHandler : IRequestHandler<GetAllEmployeesQuerry, List<Employee>>
    {
        private readonly TestTaskDbContext context;

        public GetAllEmployeesQuerryHandler(TestTaskDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuerry request, CancellationToken cancellationToken)
        {
            var employees = await context.Employees.ToListAsync();

            if(employees == null)
            {
                throw new ArgumentException("Employees were not found");
            }

            return employees;
        }
    }
}
