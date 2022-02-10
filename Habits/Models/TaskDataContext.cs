using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Habits.Models
{
    public class TaskDataContext : DbContext
    {

        //Setting up the Constructor
        public TaskDataContext(DbContextOptions<TaskDataContext> options) : base(options)
        {
            //Come back to this later
        }
        public DbSet<TaskResponse> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
                );

            mb.Entity<TaskResponse>().HasData(
                new TaskResponse
                {
                    TaskID = 1,
                    TaskName = "Homework for IS",
                    CategoryId = 2,
                    DueDate = new DateTime(2022, 5, 1),
                    Completed = false,
                    Quadrant = 1
                },
                new TaskResponse
                {
                    TaskID = 2,
                    TaskName = "Repent",
                    CategoryId = 4,
                    DueDate = new DateTime(2022, 5, 1),
                    Completed = false,
                    Quadrant = 1
                },
                new TaskResponse
                {
                    TaskID = 3,
                    TaskName = "Get Paid",
                    CategoryId = 3,
                    DueDate = new DateTime(2022, 5, 1),
                    Completed = false,
                    Quadrant = 2
                },
                new TaskResponse
                {
                    TaskID = 4,
                    TaskName = "Take Out Trash",
                    CategoryId = 1,
                    DueDate = new DateTime(2022, 5, 1),
                    Completed = false,
                    Quadrant = 3
                },
                new TaskResponse
                {
                    TaskID = 5,
                    TaskName = "Go to IS 455 Lecture",
                    CategoryId = 2,
                    DueDate = new DateTime(2022, 5, 1),
                    Completed = false,
                    Quadrant = 4
                }
            );
        }
    }
}

