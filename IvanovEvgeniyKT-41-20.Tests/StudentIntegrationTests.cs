﻿using IvanovEvgeniyKT_41_20.Database;
using IvanovEvgeniyKT_41_20.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IvanovEvgeniyKT_41_20.Interfaces.StudentInterfaces.IStudentService;
using IvanovEvgeniyKT_41_20.Interfaces.StudentInterfaces;


namespace IvanovEvgeniyKT_41_20.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<IvanovDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {

            _dbContextOptions = new DbContextOptionsBuilder<IvanovDbContext>().UseInMemoryDatabase(databaseName: "prpr1").Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT3120_TwoObjects()
        {
            // Arrange
            var ctx = new IvanovDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-20"
                },
                new Group
                {
                    GroupName = "KT-41-20"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.StudentFilters.StudentGroupFilter
            {
                GroupName = "KT-41-20"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }
    }
}
