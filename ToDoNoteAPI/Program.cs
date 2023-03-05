using Microsoft.EntityFrameworkCore;
using ToDoNoteData.Data;
//using ToDoNoteAPI.Interfaces;
//using ToDoNoteAPI.Repository;
using ToDoNoteService.Interface;
using ToDoNoteService.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //builder.Services.AddScoped<INoteRepository, NoteRepository>();
        builder.Services.AddScoped<INoteService, NoteService>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<dbConnection>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("myConnection")
            )
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}