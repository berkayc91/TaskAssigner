using Core.DataAccess.Configs;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Entity.Entities.Task;

namespace DataAccess.Contexts
{
    public class TaskAssignerContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TaskAssignerDB;User ID=sa;Password=sa; TrustServerCertificate=True ;MultipleActiveResultSets=true");
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Task>().HasData(
                new Task { TaskId = 1, Name = "Easy Task", Difficulty = 1, DifficultyColorCode = "#00FF00" },
                new Task { TaskId = 2, Name = "Simple Task", Difficulty = 2, DifficultyColorCode = "#33FF00" },
                new Task { TaskId = 3, Name = "Basic Task", Difficulty = 3, DifficultyColorCode = "#66FF00" },
                new Task { TaskId = 4, Name = "Intermediate Task", Difficulty = 4, DifficultyColorCode = "#99FF00" },
                new Task { TaskId = 5, Name = "Advanced Task", Difficulty = 5, DifficultyColorCode = "#CCFF00" },
                new Task { TaskId = 6, Name = "Difficult Task", Difficulty = 6, DifficultyColorCode = "#FF0000" }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, Name = "Ahmet", Surname = "Kılıç", TotalScore = 1, ActiveTaskId = 1 },
                new Employee { EmployeeId = 2, Name = "Ayşe", Surname = "Yılmaz", TotalScore = 2, ActiveTaskId = 2 },
                new Employee { EmployeeId = 3, Name = "Mehmet", Surname = "Kaya", TotalScore = 3, ActiveTaskId = 3 },
                new Employee { EmployeeId = 4, Name = "Fatma", Surname = "Aslan", TotalScore = 4, ActiveTaskId = 4 },
                new Employee { EmployeeId = 5, Name = "Ali", Surname = "Şahin", TotalScore = 5, ActiveTaskId = 5 },
                new Employee { EmployeeId = 6, Name = "Merve", Surname = "Ak", TotalScore = 6, ActiveTaskId = 6 }
                );
            modelBuilder.Entity<TaskHistory>().HasData(
                new TaskHistory { TaskHistoryId = 1, EmployeeId = 1, TaskId = 1, TaskDate = DateTime.Now },
                new TaskHistory { TaskHistoryId = 2, EmployeeId = 2, TaskId = 2, TaskDate = DateTime.Now },
                new TaskHistory { TaskHistoryId = 3, EmployeeId = 3, TaskId = 3, TaskDate = DateTime.Now },
                new TaskHistory { TaskHistoryId = 4, EmployeeId = 4, TaskId = 4, TaskDate = DateTime.Now },
                new TaskHistory { TaskHistoryId = 5, EmployeeId = 5, TaskId = 5, TaskDate = DateTime.Now },
                new TaskHistory { TaskHistoryId = 6, EmployeeId = 6, TaskId = 6, TaskDate = DateTime.Now }
                );

        }

    }
}
