namespace EmployeeService.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Employee GetEmployeeById(int id);

        void EnableEmployee(int id, bool enable);
    }
}
