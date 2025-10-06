using Microsoft.EntityFrameworkCore;
using MyTask = Todo.Todo;

namespace Program
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TasksDb>(opt =>
                opt.UseInMemoryDatabase("Tasks"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            var app = builder.Build();


            // Search tasks from the database (1st: all tasks | 2nd: the completed ones | 3rd: by their id )
            app.MapGet("/tasks", async (TasksDb db) =>
                await db.Tasks.ToListAsync());
            
            app.MapGet("/tasks/complete", async (TasksDb db) => 
                await db.Tasks.Where(t => t.IsCompleted).ToListAsync());

            app.MapGet("/tasks/{id}", async (int id, TasksDb db) =>
                await db.Tasks.FindAsync(id)
                    is MyTask task ? Results.Ok(task) : Results.NotFound());


            // Add new tasks to the database
            app.MapPost("/tasks", async (MyTask task, TasksDb db) =>
            {
                db.Tasks.Add(task);
                await db.SaveChangesAsync();

                return Results.Created($"/tasks/{task.Id}", task);
            });


            // Modifies a task by id
            app.MapPut("/tasks/{id}", async (int id, MyTask inputTask, TasksDb db) =>
            {
                var task = await db.Tasks.FindAsync(id);

                if (task == null) return Results.NotFound();

                task.Title = inputTask.Title;
                task.Description = inputTask.Description;
                task.IsCompleted = inputTask.IsCompleted;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });


            // Deletes one task by id
            app.MapDelete("/tasks/{id}", async (int id, TasksDb db) =>
            {
                if (await db.Tasks.FindAsync(id) is MyTask task)
                {
                    db.Tasks.Remove(task);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }
                return Results.NotFound();
            });

            app.Run();
        }
    }
}
