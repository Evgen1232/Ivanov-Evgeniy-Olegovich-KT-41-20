using IvanovEvgeniyKT_41_20.Interfaces.StudentInterfaces;
using static IvanovEvgeniyKT_41_20.Interfaces.StudentInterfaces.IStudentService;

namespace IvanovEvgeniyKT_41_20.ServiceExtensions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}
