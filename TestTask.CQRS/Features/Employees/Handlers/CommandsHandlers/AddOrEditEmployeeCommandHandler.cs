using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.CQRS.Features.Employees.Commands;
using TestTask.DataBase.Data;
using TestTask.DataBase.Models;

namespace TestTask.CQRS.Features.Employees.Handlers.CommandsHandlers
{
    internal class AddOrEditEmployeeCommandHandler : IRequestHandler<AddOrEditEmployeeCommand, int>
    {
        private readonly TestTaskDbContext context;

        public AddOrEditEmployeeCommandHandler(TestTaskDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(AddOrEditEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.Employee.Id == 0)
            {
                await context.Employees.AddAsync(request.Employee);
                await context.SaveChangesAsync();
                Console.WriteLine();
                return request.Employee.Id;
            }
            else
            {
                var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == request.Employee.Id);
                if (employee == null)
                {
                    throw new ArgumentException("Player was not found found");
                }
                employee.Name = request.Employee.Name;
                employee.Phone = request.Employee.Phone;
                employee.Title = request.Employee.Title;
                employee.BirthDay = request.Employee.BirthDay;
                await context.SaveChangesAsync();
                return request.Employee.Id;
            }
        }
    }
}
