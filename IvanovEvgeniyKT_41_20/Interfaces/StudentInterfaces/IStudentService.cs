using IvanovEvgeniyKT_41_20.Database;
using IvanovEvgeniyKT_41_20.Models;
using IvanovEvgeniyKT_41_20.Filters.StudentFilters;
using Microsoft.EntityFrameworkCore;

namespace IvanovEvgeniyKT_41_20.Interfaces.StudentInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }
    public class StudentService : IStudentService
    {
        private IvanovDbContext _dbContext;
        public StudentService(IvanovDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
            return students;
        }
    }
}
