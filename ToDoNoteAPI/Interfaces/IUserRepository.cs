using ToDoNoteAPI.Models;

namespace ToDoNoteAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        Note GetParticularById(int id);
        bool ifIdExist(int id);
        bool AddNewUser(User user);
        bool UpdateUser(User user);
        bool DeleteUSer(int id);
        bool Save();
    }
}
