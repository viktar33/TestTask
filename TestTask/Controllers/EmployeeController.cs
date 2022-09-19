using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTask.CQRS.Features.Employees.Commands;
using TestTask.CQRS.Features.Employees.Querries;
using TestTask.DataBase.Models;

namespace MyProject.Web.Controllers
{
    [Route("[employeeController]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator mediator;


        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("/GetAllEmployees")]
        [HttpGet]
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await mediator.Send(new GetAllEmployeesQuerry());
        }

        [Route("/GetEmployeeById/{id}")]
        [HttpGet]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await mediator.Send(new GetEmployeeByIdQuerry(id));
        }

        [Route("/AddOrEditEmployee")]
        [HttpPost]
        public async Task<int> AddOrEditEmployee([FromBody] Employee employee)
        {
            return await mediator.Send(new AddOrEditEmployeeCommand(employee));
        }

        [Route("/DeleteEmployee")]
        [HttpDelete]
        public async Task<int> DeleteEmployee(int id)
        {
            return await mediator.Send(new DeleteEmployeeCommand(id));
        }
    }
}
