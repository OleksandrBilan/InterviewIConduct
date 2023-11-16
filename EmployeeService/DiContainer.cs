using Autofac;
using EmployeeService.Repositories.Interfaces;
using EmployeeService.Services.Interfaces;

public static class DiContainer
{
    public static IContainer Register()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<EmployeesRepository>().As<IEmployeesRepository>();
        builder.RegisterType<EmployeesService>().As<IEmployeesService>();

        return builder.Build();
    }
}