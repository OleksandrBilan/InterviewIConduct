using Autofac;
using EmployeeService.Services.Interfaces;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IEmployeeService
    {
        private readonly IEmployeesService _employeesService;

        public Service1()
        {
            var container = DiContainer.Register();
            _employeesService = container.Resolve<IEmployeesService>();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeesService.GetEmployeeById(id);
        }

        public void EnableEmployee(int id, bool enable)
        {
            _employeesService.EnableEmployee(id, enable);
        }
    }
}