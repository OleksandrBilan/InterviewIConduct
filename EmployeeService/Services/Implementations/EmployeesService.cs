using EmployeeService.Repositories.Interfaces;
using EmployeeService.Services.Interfaces;

public class EmployeesService : IEmployeesService
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesService(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public Employee GetEmployeeById(int id)
    {
        return _employeesRepository.GetEmployeeById(id);
    }

    public void EnableEmployee(int id, bool enable)
    {
        _employeesRepository.EnableEmployee(id, enable);
    }
}