using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DataBase.Models;

namespace TestTask.CQRS.Features.Employees.Querries
{
    public class GetAllEmployeesQuerry : IRequest<List<Employee>>
    {
        
    }
}
