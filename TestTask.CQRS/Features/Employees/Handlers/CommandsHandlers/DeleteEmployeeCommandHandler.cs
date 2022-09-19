using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.CQRS.Features.Employees.Commands;
using TestTask.DataBase.Data;

namespace TestTask.CQRS.Features.Employees.Handlers.CommandsHandlers
{
    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand,int>
    {
        private readonly TestTaskDbContext context;

        public DeleteEmployeeCommandHandler(TestTaskDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (employee == null)
            {
                throw new ArgumentException("Employee was not found");
            }
            context.Employees.Remove(employee);

            await context.SaveChangesAsync();

            return request.Id;
        }
    }
}
