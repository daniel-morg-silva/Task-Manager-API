using Microsoft.EntityFrameworkCore;
using MyTask = Todo.Todo;

class TasksDb(DbContextOptions<TasksDb> options) : DbContext (options)
{
    public DbSet<MyTask> Tasks => Set<MyTask>(); 
}