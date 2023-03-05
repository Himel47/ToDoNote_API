using Microsoft.EntityFrameworkCore;
using ToDoNoteData.Entities;

namespace ToDoNoteData.Data
{
    public class dbConnection : DbContext
    {
        public dbConnection(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
